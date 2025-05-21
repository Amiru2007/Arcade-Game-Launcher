using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

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

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            // Clear saved token
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("authToken");
            localSettings.Values.Remove("username");

            // Navigate back to login
            if (Window.Current.Content is Frame frame)
            {
                frame.Navigate(typeof(LoginPage));
            }
        }
    }
}
