using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ComposeWindowViewModel
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        Email email;

        public void ComposeMail()
        {
            email = new Email(Recipient, Subject, Body);
        }

        public void SendMail()
        {
            MessageService.SendMail(email);
        }

        public bool IsReadyToSend()
        {
            if (!IsRecipientOK()) { return false; }
            if (!IsSubjectOK()) { return false; }
            if (!IsBodyOK()) { return false; }
            return true;
        }

        private bool IsRecipientOK()
        {
            if (string.IsNullOrEmpty(Recipient))
            {
                _ = MessageBox.Show("You can't send a mail without a recipient!", "Alert", MessageBoxButton.OK);
                return false;
            }

            if (!IsEmailAdressValid())
            {
                MessageBox.Show("Email address is invalid!");
                return false;
            }
            return true;

        }

        private bool IsEmailAdressValid()
        {
            return Regex.IsMatch(Recipient, @"^[\w-.]+@([\w-]+.)+[\w-]{2,3}$");
        }

        private bool IsSubjectOK()
        {
            //Checks if subject is empty. If empty, it asks the user if it's OK to send the mail without subject. 
            //If not empty, it returns true, signaling the subject is ready to send.
            return string.IsNullOrEmpty(Subject) ? AskIfEmptyIsOK(nameof(Subject)) : true;
        }

        private bool IsBodyOK()
        {
            //Checks if body is empty. If empty, it asks the user if it's OK to send the mail without body. 
            //If not empty, it returns true, signaling the body is ready to send.
            return String.IsNullOrEmpty(Body) ? AskIfEmptyIsOK(nameof(Body)) : true;
        }

        private bool AskIfEmptyIsOK(string property)
        {
            MessageBoxResult alert = MessageBox.Show($"You are sending the E-mail without {property.ToLower()}. Continue?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return alert.Equals(MessageBoxResult.Yes);
        }

        public bool IsReadyToCancel()
        {
            if (!String.IsNullOrEmpty(Body))
            {
                MessageBoxResult alert = MessageBox.Show("Do you want to discard this E-mail?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question);
                return alert.Equals(MessageBoxResult.Yes);
            }
            return true;
        }
    }
}
