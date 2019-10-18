using SaintSender.Core.Entities;
using SaintSender.DesktopUI.ViewModels;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginWindowViewModel loginWindowViewModel;
        public LoginWindow()
        {
            InitializeComponent();
            loginWindowViewModel = new LoginWindowViewModel();
            this.DataContext = loginWindowViewModel;
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindowViewModel.CanLogin())
            {
                loginWindowViewModel.ExecuteLogin();
                User user = new User(loginWindowViewModel.userName, loginWindowViewModel.password);
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
