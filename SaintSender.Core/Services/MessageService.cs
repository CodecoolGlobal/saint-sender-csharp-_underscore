using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Entities;
using MailKit.Search;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows;

namespace SaintSender.Core.Services
{
    public class MessageService
    {

        private LoginWindowviewModel LoginWindowviewModel;
        private ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();
        public ImapClient client;


        public MessageService(User user)
        {
            client = new ImapClient();
            Connection(user.UserName, user.Password);
        }

        public void Connection(string userName, string password)
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(userName, password);
        }


        public ObservableCollection<Email> GetMails()
        {
            client.Inbox.Open(FolderAccess.ReadOnly);
            IList<UniqueId> uniqueIds = client.Inbox.Search(SearchQuery.All);
            foreach (UniqueId uniqueId in uniqueIds)
            {
                MimeMessage message = client.Inbox.GetMessage(uniqueId);
                emails.Add(new Email(message.From, message.Subject, message.Body, message.Date));
            }
            //client.Disconnect(true);
            return emails;
        }

        public static void SendMail(Email email)
        {
            MimeMessage message = new MimeMessage();
            BodyBuilder bodyBuilder = new BodyBuilder();
            message.From.Add(new MailboxAddress("underscoretestemail@gmail.com"));
            message.To.Add(new MailboxAddress(email.Recipient));
            message.Subject = email.Subject;
            bodyBuilder.HtmlBody = email.Body;
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("smtp.gmail.com", 587);
            client.Authenticate("underscoretestemail", "wjurtaqxhvfupaal");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
