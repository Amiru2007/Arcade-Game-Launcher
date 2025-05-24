using Microsoft.UI.Xaml;
using Windows.Storage;

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
            var localSettings = ApplicationData.Current.LocalSettings;
            var isLoggedIn = (bool?)localSettings.Values["IsLoggedIn"] ?? false;

            Window window;

            if (isLoggedIn)
            {
                window = new MainWindow();
            }
            else
            {
                window = new LoginWindow(); // You need to have this defined if using separate login window
            }

            window.Activate();
        }

        public static Window loginWindow;
        public static Window mainWindow;
    }
}
