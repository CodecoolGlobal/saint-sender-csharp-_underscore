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
        private InternetAddressList From { get; set; }
        public string Subject { get; set; }

        private MimeEntity Body;


        public Email(InternetAddressList from, string subject, MimeEntity body)
        {
            From = from;
            Subject = subject;
            Body = body;
        }
    }
}
