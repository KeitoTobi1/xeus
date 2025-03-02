using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Omnius.Axis.Intaractors;
using Omnius.Axis.Intaractors.Models;
using Omnius.Axis.Ui.Desktop.Configuration;
using Omnius.Axis.Ui.Desktop.Internal;
using Omnius.Core;
using Omnius.Core.Avalonia;
using Reactive.Bindings;

namespace Omnius.Axis.Ui.Desktop.Views.Main;

public class UploadControlViewModel : AsyncDisposableBase
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly UiStatus _uiState;
    private readonly IIntaractorProvider _intaractorAdapter;
    private readonly IApplicationDispatcher _applicationDispatcher;
    private readonly IDialogService _dialogService;
    private readonly IClipboardService _clipboardService;

    private readonly CollectionViewUpdater<UploadingFileViewModel, UploadingFileReport> _uploadingFilesUpdater;
    private readonly ObservableCollection<UploadingFileViewModel> _selectedFiles = new();

    private readonly CompositeDisposable _disposable = new();

    public UploadControlViewModel(UiStatus uiState, IIntaractorProvider intaractorAdapter, IApplicationDispatcher applicationDispatcher, IDialogService dialogService, IClipboardService clipboardService)
    {
        _uiState = uiState;
        _intaractorAdapter = intaractorAdapter;
        _applicationDispatcher = applicationDispatcher;
        _dialogService = dialogService;
        _clipboardService = clipboardService;

        _uploadingFilesUpdater = new CollectionViewUpdater<UploadingFileViewModel, UploadingFileReport>(_applicationDispatcher, this.GetUploadingFileReports, TimeSpan.FromSeconds(3), UploadingFileReportEqualityComparer.Default);

        this.AddCommand = new ReactiveCommand().AddTo(_disposable);
        this.AddCommand.Subscribe(() => this.Register()).AddTo(_disposable);

        this.ItemDeleteCommand = new ReactiveCommand().AddTo(_disposable);
        this.ItemDeleteCommand.Subscribe(() => this.ItemDelete()).AddTo(_disposable);

        this.ItemCopySeedCommand = new ReactiveCommand().AddTo(_disposable);
        this.ItemCopySeedCommand.Subscribe(() => this.ItemCopySeed()).AddTo(_disposable);
    }

    protected override async ValueTask OnDisposeAsync()
    {
        _disposable.Dispose();
        await _uploadingFilesUpdater.DisposeAsync();
    }

    private async ValueTask<IEnumerable<UploadingFileReport>> GetUploadingFileReports(CancellationToken cancellationToken)
    {
        var fileUploader = await _intaractorAdapter.GetFileUploaderAsync(cancellationToken);

        return await fileUploader.GetUploadingFileReportsAsync(cancellationToken);
    }

    private class UploadingFileReportEqualityComparer : IEqualityComparer<UploadingFileReport>
    {
        public static UploadingFileReportEqualityComparer Default { get; } = new();

        public bool Equals(UploadingFileReport? x, UploadingFileReport? y)
        {
            return (x?.FilePath == y?.FilePath);
        }

        public int GetHashCode([DisallowNull] UploadingFileReport obj)
        {
            return obj?.FilePath?.GetHashCode() ?? 0;
        }
    }

    public ReactiveCommand AddCommand { get; }

    public ReadOnlyObservableCollection<UploadingFileViewModel> UploadingFiles => _uploadingFilesUpdater.Collection;

    public ObservableCollection<UploadingFileViewModel> SelectedFiles { get; } = new();

    public ReactiveCommand ItemDeleteCommand { get; }

    public ReactiveCommand? ItemCopySeedCommand { get; }

    private async void Register()
    {
        var fileUploader = await _intaractorAdapter.GetFileUploaderAsync();

        foreach (var filePath in await _dialogService.ShowOpenFileWindowAsync())
        {
            await fileUploader.RegisterAsync(filePath, Path.GetFileName(filePath));
        }
    }

    private async void ItemDelete()
    {
        var fileUploader = await _intaractorAdapter.GetFileUploaderAsync();

        var selectedFiles = this.SelectedFiles.ToArray();
        if (selectedFiles.Length == 0) return;

        foreach (var viewModel in selectedFiles)
        {
            if (viewModel.Model?.FilePath is string filePath)
            {
                await fileUploader.UnregisterAsync(filePath);
            }
        }
    }

    private async void ItemCopySeed()
    {
        var selectedFiles = this.SelectedFiles.ToArray();
        if (selectedFiles.Length == 0) return;

        var sb = new StringBuilder();
        foreach (var file in selectedFiles)
        {
            if (file.Model?.Seed is null) continue;
            sb.AppendLine(AxisMessage.SeedToString(file.Model.Seed));
        }

        await _clipboardService.SetTextAsync(sb.ToString());
    }
}
