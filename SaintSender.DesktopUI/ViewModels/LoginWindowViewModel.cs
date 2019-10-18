using SaintSender.Core.Services;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    public class LoginWindowViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }

        public void ExecuteLogin()
        {
            LoginService.Login(userName, password);
        }

        public bool CanLogin()
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all of the fields!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
