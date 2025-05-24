using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
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
        }
    }
}
