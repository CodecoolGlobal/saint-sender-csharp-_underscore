using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class LoginService
    {

        //string pw = "wjurtaqxhvfupaal";
        //string email = "undescoretestemail@gmail.com";

        public static void Login(string userName, string password)
        {
            ImapClient client = new ImapClient();
            client.Connect("imap.gmail.com", 993, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(userName, password);
        }

        
    }
}
