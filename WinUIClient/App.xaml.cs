using Microsoft.UI.Xaml;

namespace WinUIClient
{
    public partial class App : Application
    {
        public static MainWindow MainWindow { get; private set; }

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            MainWindow = new MainWindow();
            MainWindow.Activate();
        }
    }
}
