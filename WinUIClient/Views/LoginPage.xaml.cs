using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Net.Http;
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

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    // Save token
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["authToken"] = result.Token;

                    // Show success dialog
                    ContentDialog dialog = new()
                    {
                        Title = "Login Successful",
                        Content = $"Welcome {result.Username}!",
                        CloseButtonText = "OK"
                    };
                    await dialog.ShowAsync();

                    // Navigate to homepage
                    Frame.Navigate(typeof(HomePage));
                }
                else
                {
                    throw new Exception("Empty token received.");
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
