using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinUIClient.Services;

namespace WinUIClient.Views
{
    public sealed partial class RegisterPage : Page
    {
        private readonly ApiService _apiService = new();

        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            try
            {
                var result = await _apiService.RegisterAsync(username, email, password);
                ContentDialog dialog = new()
                {
                    Title = "Registration Successful",
                    Content = $"Account created for {result.Username}",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
            }
            catch
            {
                ContentDialog errorDialog = new()
                {
                    Title = "Registration Failed",
                    Content = "Email might already be registered.",
                    CloseButtonText = "OK"
                };
                await errorDialog.ShowAsync();
            }
        }
    }
}
