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


        public static bool ValidEmailAdress(string email)
        {
            if(!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$"))
            {
                MessageBox.Show("Email address is invalid!");
                return false;
            }
            return true;
        }

        public void ExecuteLogin()
        {
            LoginService.Login(userName, password);
        }

        //public void ExecuteSignIncommand(object parameter)
        //{
        //    var passwordBox = parameter as PasswordBox;
        //    password = passwordBox.Password;
        //    //LoginService.
        //}
    }
}
