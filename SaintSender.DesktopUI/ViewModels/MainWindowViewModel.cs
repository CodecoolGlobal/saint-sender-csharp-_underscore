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
   public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();


        public MainWindowViewModel()
        {
            MessageService messageService = new MessageService();
            emails = messageService.getlist();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
