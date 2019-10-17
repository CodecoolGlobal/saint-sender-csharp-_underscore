using SaintSender.Core.Entities;
using SaintSender.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            loginWindowViewModel.ExecuteLogin();
            User user = new User(loginWindowViewModel.userName, loginWindowViewModel.password);
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Close();
            //if (LoginWindowViewModel.ValidEmailAdress(EmailTxt.Text))
            //{
            //    //loginWindowViewModel.ExecuteSignIncommand(PasswordTxt.Text);
            //    loginWindowViewModel.ExecuteLogin();
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();
            //    Close();
            //}
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(PasswordTxt.Password);
        }
    }
}
