﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace SaintSender.Core.Entities
{
    public class Email
    {
        public string From { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Date { get; set; }


        public Email(InternetAddressList from, string subject, MimeEntity body, DateTimeOffset date)
        {
            From = from.ToString();
            Subject = subject;
            Body = body.ToString();
            Date = date.ToString();
        }
    }
}