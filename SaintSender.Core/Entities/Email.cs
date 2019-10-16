using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace SaintSender.Core.Entities
{
    public class Email
    {
        public int MessageId { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Date { get; set; }


        public Email(int messageId, InternetAddressList from, string subject, string body, DateTimeOffset date)
        {
            MessageId = messageId;
            From = from.ToString();
            Subject = subject;
            Body = body;
            Date = date.ToString();
        }
    }
}
