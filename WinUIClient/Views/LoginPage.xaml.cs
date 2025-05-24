using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Net.Http;
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

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    // Save login state and info
                    ApplicationData.Current.LocalSettings.Values["IsLoggedIn"] = true;
                    ApplicationData.Current.LocalSettings.Values["Username"] = result.Username;
                    ApplicationData.Current.LocalSettings.Values["AuthToken"] = result.Token;

                    // Open MainWindow
                    App.mainWindow = new MainWindow();
                    App.mainWindow.Activate();

                    // Close LoginWindow if you use a separate one
                    App.loginWindow?.Close();
                }
                else
                {
                    throw new Exception("Received empty or null token.");
                }
            }
            catch (HttpRequestException ex)
            {
                await new ContentDialog
                {
                    Title = "Network Error",
                    Content = $"Could not connect to server.\n\n{ex.Message}",
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Login Failed",
                    Content = $"Invalid credentials or server error.\n\n{ex.Message}",
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
        }
    }
}
