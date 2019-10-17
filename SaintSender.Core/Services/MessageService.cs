using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SaintSender.Core.Entities;
using MailKit.Search;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Threading;
using System;

namespace SaintSender.Core.Services
{
    public class MessageService
    {

        private ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();
        public static ImapClient client;
        private static string _userName;
        private static string _password;


        public MessageService(User user)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Start();
            client = new ImapClient();
            Connection(user.UserName, user.Password);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetMails().Clear();
            GetMails();
        }

        public static void Connection(string userName, string password)
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(userName, password);
            _userName = userName;
            _password = password;
        }


        public ObservableCollection<Email> GetMails()
        {
            client.Inbox.Open(FolderAccess.ReadOnly);
            IList<UniqueId> uniqueIds = client.Inbox.Search(SearchQuery.All);
            foreach (UniqueId uniqueId in uniqueIds)
            {
                MimeMessage message = client.Inbox.GetMessage(uniqueId);
                emails.Add(new Email(message.From, message.Subject, message.HtmlBody, message.Date));
            }
            return emails;
        }

        public static void SendMail(Email email)
        {
            MimeMessage message = new MimeMessage();
            BodyBuilder bodyBuilder = new BodyBuilder();
            message.From.Add(new MailboxAddress(_userName + "@gmail.com"));
            message.To.Add(new MailboxAddress(email.Recipient));
            message.Subject = email.Subject;
            bodyBuilder.HtmlBody = email.Body;
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("smtp.gmail.com", 587);
            client.Authenticate(_userName, _password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}