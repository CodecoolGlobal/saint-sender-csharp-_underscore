using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
   public class MainWindowViewModel
    {
        
        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>();
        

        public MainWindowViewModel(User user)
        {
            MessageService messageService = new MessageService(user);
            Emails = messageService.GetMails();
        }

    }
}
