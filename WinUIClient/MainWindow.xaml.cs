using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.Networking.NetworkOperators;
using Windows.UI.ApplicationSettings;
using WinUIClient.Views;

namespace WinUIClient
{
    public sealed partial class MainWindow : Window
    {
        // Make ContentFrame public so other classes can access it
        public Frame ContentFrame => contentFrame;

        public MainWindow()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(LoginPage));

            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("authToken"))
            {
                contentFrame.Navigate(typeof(HomePage));
            }
            else
            {
                contentFrame.Navigate(typeof(LoginPage));
            }
        }

        private void NavigationView_SelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItem is NavigationViewItem item)
            {
                switch (item.Tag)
                {
                    case "GamesPage":
                        contentFrame.Navigate(typeof(GamesPage));
                        break;
                    case "ChatPage":
                        contentFrame.Navigate(typeof(ChatPage));
                        break;
                    case "ProfilePage":
                        contentFrame.Navigate(typeof(ProfilePage));
                        break;
                    case "SettingsPage":
                        contentFrame.Navigate(typeof(SettingsPage));
                        break;
                }
            }
        }
    }
}
