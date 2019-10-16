using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    public class LoginWindowViewModel
    {
        public static bool ValidEmailAdress(string email)
        {
            if(!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$"))
            {
                MessageBox.Show("Email address is invalid!");
                return false;
            }
            return true;
        }
    }
}
