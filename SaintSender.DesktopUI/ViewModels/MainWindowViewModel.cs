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
    public class MainWindowViewModel : ViewModelBase
    {

        public ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();
        private Email _selectedEmail;
        public Email selectedEmail
        {
            get
            {
                return _selectedEmail;
            }
            set
            {
                OnPropertyChanged();
                _selectedEmail = value;
            }
        }

        public MainWindowViewModel()
        {
            MessageService messageService = new MessageService();
            emails = messageService.getlist();
        }

    }
}
