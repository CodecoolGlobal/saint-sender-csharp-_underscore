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
using System.Windows.Threading;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Gmail.v1;

namespace SaintSender.Core.Services
{
    public class MessageService
    {

        private ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();
        public ImapClient client;


        public MessageService(User user)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
            client = new ImapClient();
            Connection(user.UserName, user.Password);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetMails().Clear();
            GetMails();
        }

        public void Connection(string userName, string password)
        {
            client.Connect("imap.gmail.com", 993, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(userName, password);
        }


        public ObservableCollection<Email> GetMails()
        {
            client.Inbox.Open(FolderAccess.ReadOnly);
            IList<UniqueId> uniqueIds = client.Inbox.Search(SearchQuery.All);
            IList<UniqueId> notSeenEmailsUniqueIds = client.Inbox.Search(SearchQuery.NotSeen);

            foreach ( UniqueId uids in notSeenEmailsUniqueIds)
            {
                MimeMessage notSeenMessage = client.Inbox.GetMessage(uids);
            }

            foreach (UniqueId uniqueId in uniqueIds)
            {
                MimeMessage message = client.Inbox.GetMessage(uniqueId);
                emails.Add(new Email(message.From, message.Subject, message.Body, message.Date));
            }
            //client.Disconnect(true);
            return emails;
        }
    }
}
