using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ComposeWindowViewModel
    {
        public String Recipient { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }

        public void CopmoseMail()
        {
            Email email = new Email(Recipient, Subject, Body);
            MessageService.SendMail(email);
        }
    }
}
