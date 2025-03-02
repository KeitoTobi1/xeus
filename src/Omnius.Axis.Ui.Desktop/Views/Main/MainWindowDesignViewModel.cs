using Omnius.Axis.Ui.Desktop.Configuration;
using Omnius.Axis.Ui.Desktop.Views.Settings;
using Omnius.Core;
using Reactive.Bindings;

namespace Omnius.Axis.Ui.Desktop.Views.Main;

public class MainWindowDesignViewModel : MainWindowViewModelBase
{
    private readonly CompositeDisposable _disposable = new();
    private readonly CompositeAsyncDisposable _asyncDisposable = new();

    public MainWindowDesignViewModel()
    {
        this.Status = new MainWindowStatus();

        this.PeersControlViewModel = new PeersControlDesignViewModel().AddTo(_asyncDisposable);

        this.SettingsCommand = new AsyncReactiveCommand().AddTo(_disposable);
        this.SettingsCommand.Subscribe(async () => await this.SettingsAsync()).AddTo(_disposable);
    }

    protected override async ValueTask OnDisposeAsync()
    {
        _disposable.Dispose();
        await _asyncDisposable.DisposeAsync();
    }

    private async Task SettingsAsync()
    {
        var window = new SettingsWindow();
        window.Show();
    }
}
