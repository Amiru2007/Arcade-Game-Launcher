using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using WinUIClient.Services;
using Windows.Storage;

namespace WinUIClient.Views
{
    public sealed partial class LoginPage : Page
    {
        private readonly ApiService _apiService = new();

        public LoginPage()
        {
            this.InitializeComponent();

            // Set input scope to email address to prevent auto-capitalization etc.
            var inputScope = new InputScope();
            inputScope.Names.Add(new InputScopeName(InputScopeNameValue.EmailSmtpAddress));
            EmailTextBox.InputScope = inputScope;

            EmailTextBox.IsSpellCheckEnabled = false;
            EmailTextBox.IsTextPredictionEnabled = false;
        }

        private async void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text.Trim();
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
