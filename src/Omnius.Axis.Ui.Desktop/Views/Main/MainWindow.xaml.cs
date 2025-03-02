using System.ComponentModel;
using Avalonia;
using Avalonia.Markup.Xaml;
using Omnius.Axis.Ui.Desktop.Configuration;
using Omnius.Core.Avalonia;

namespace Omnius.Axis.Ui.Desktop.Views.Main;

public partial class MainWindow : StatefulWindowBase<MainWindowViewModelBase>
{
    public MainWindow()
        : base()
    {
        this.InitializeComponent();
        this.GetObservable(ViewModelProperty).Subscribe(this.OnViewModelChanged);
        this.Closing += new EventHandler<CancelEventArgs>((_, _) => this.OnClosing());
        this.Closed += new EventHandler((_, _) => this.OnClosed());
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnViewModelChanged(MainWindowViewModelBase? viewModel)
    {
        if (viewModel?.Status is MainWindowStatus status)
        {
            this.SetWindowStatus(status.Window);
        }
    }

    private void OnClosing()
    {
        if (this.ViewModel?.Status is MainWindowStatus status)
        {
            status.Window = this.GetWindowStatus();
        }
    }

    private async void OnClosed()
    {
        if (this.ViewModel is IAsyncDisposable disposable)
        {
            await disposable.DisposeAsync();
        }
    }
}
