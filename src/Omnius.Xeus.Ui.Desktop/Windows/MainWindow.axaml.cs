using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Omnius.Xeus.Ui.Desktop.Windows.Primitives;

namespace Omnius.Xeus.Ui.Desktop.Windows
{
    public partial class MainWindow : StatefulWindowBase
    {
        public MainWindow()
            : base()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override async ValueTask OnInitializeAsync()
        {
            string stateDirectoryPath = App.Current.Lifetime!.Args[0];
            await Bootstrapper.Instance.BuildAsync(stateDirectoryPath);
            this.ViewModel = Bootstrapper.Instance.ServiceProvider?.GetRequiredService<MainWindowViewModel>();
        }

        protected override async ValueTask OnDisposeAsync()
        {
            if (this.ViewModel is MainWindowViewModel viewModel)
            {
                await viewModel.DisposeAsync();
            }
        }

        public MainWindowViewModel? ViewModel
        {
            get => this.DataContext as MainWindowViewModel;
            set => this.DataContext = value;
        }
    }
}
