using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SaintSender.DesktopUI.ViewModels
{
    public class LoginWindowViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }

        public void ExecuteLogin()
        {
            if (CanLogin())
            {
                LoginService.Login(userName, password);
            }
        }

        public bool CanLogin()
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all of the fields!", "Alert", MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
