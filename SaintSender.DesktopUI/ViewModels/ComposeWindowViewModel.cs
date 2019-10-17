using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ComposeWindowViewModel
    {
        public String Recipient { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }

        Email email;

        public void CopmoseMail()
        {
            email = new Email(Recipient, Subject, Body);
        }

        public void Send()
        {
            MessageService.SendMail(email);
        }

        public bool IsReadyToSend()
        {
            bool RecipientIsOK = IsRecipientOK();
            if (!RecipientIsOK) { return false; }
            bool SubjectIsOK = IsSubjectOK();
            if (!SubjectIsOK) { return false; }
            bool BodyIsOK = IsBodyOK();
            if (!BodyIsOK) { return false; }
            return true;
        }

        private bool IsRecipientOK()
        {
            if (String.IsNullOrEmpty(Recipient))
            {
                _ = MessageBox.Show("You can't send a mail without a recipient!", "Alert", MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsSubjectOK()
        {
            if (String.IsNullOrEmpty(Subject))
            {
                if (AskIfEmptyIsOK(nameof(Subject)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool IsBodyOK()
        {
            if (String.IsNullOrEmpty(Body))
            {
                if (AskIfEmptyIsOK(nameof(Body)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool AskIfEmptyIsOK(String propertyType)
        {
            MessageBoxResult alert = MessageBox.Show($"You are sending the mail without {propertyType.ToLower()}. Continue?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (alert)
            {
                case MessageBoxResult.Yes:
                    return true;

                case MessageBoxResult.No:
                    return false;
            }
            throw new ArgumentException("Error!!!!!!");
        }
    }
}
