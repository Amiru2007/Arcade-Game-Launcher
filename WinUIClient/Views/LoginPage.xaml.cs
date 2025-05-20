using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinUIClient.Services;

namespace WinUIClient.Views
{
    public sealed partial class LoginPage : Page
    {
        private readonly ApiService _apiService = new();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            try
            {
                var result = await _apiService.LoginAsync(email, password);

                ContentDialog dialog = new()
                {
                    Title = "Login Successful",
                    Content = $"Welcome {result.Username}!",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();

                var mainWindow = App.MainWindow;
                mainWindow.ContentFrame.Navigate(typeof(HomePage));
            }
            catch
            {
                ContentDialog errorDialog = new()
                {
                    Title = "Login Failed",
                    Content = "Invalid credentials.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await errorDialog.ShowAsync();
            }
        }
    }
}
