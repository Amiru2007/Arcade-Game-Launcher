using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear any stored data
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("AuthToken");

            ApplicationData.Current.LocalSettings.Values["IsLoggedIn"] = false;
            ApplicationData.Current.LocalSettings.Values["Username"] = null;

             ApplicationData.Current.LocalSettings.Values["AuthToken"] = null;

            // Open login window
            App.loginWindow = new LoginWindow();
            App.loginWindow.Activate();

            // Close main window
            App.mainWindow.Close();
        }
    }
}
