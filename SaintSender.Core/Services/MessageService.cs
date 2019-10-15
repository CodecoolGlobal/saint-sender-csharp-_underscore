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

namespace SaintSender.Core.Services
{
    public class MessageService
    {
        private ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();

        public MessageService()
        {
            Connection();
        }

        public void Connection()
        {
            using(ImapClient client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate("underscoretestemail", "wjurtaqxhvfupaal");
                client.Inbox.Open(FolderAccess.ReadOnly);
                IList<UniqueId> uniqueIds = client.Inbox.Search(SearchQuery.All);

                foreach (UniqueId uniqueId in uniqueIds)
                {
                    MimeMessage message = client.Inbox.GetMessage(uniqueId);
                    emails.Add(new Email(message.From, message.Subject, message.Body));
                }
                client.Disconnect(true);
            }
        }

        public ObservableCollection<Email> getlist()
        {
            return emails;
        }
    }
}
