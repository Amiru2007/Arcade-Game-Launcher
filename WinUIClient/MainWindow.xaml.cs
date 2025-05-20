using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIClient.Views;

namespace WinUIClient
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(LoginPage));
        }
    }
}
