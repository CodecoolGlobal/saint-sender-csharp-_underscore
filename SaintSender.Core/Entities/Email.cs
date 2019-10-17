using System;
using MimeKit;

namespace SaintSender.Core.Entities
{
    public class Email
    {
        public string From { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }

        public Email(InternetAddressList from, string subject, string body, DateTimeOffset date)
        {
            From = from.ToString();
            Subject = subject;
            Body = body;
            Date = date.ToString("yyyy MMM dd HH:mm");
        }

        public Email(string recipient, string subject, string body)
        {
            Recipient = recipient;
            Subject = subject ?? "";
            Body = body ?? "";
        }
    }
}