using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System.Collections.ObjectModel;

namespace SaintSender.DesktopUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>();
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

        public MainWindowViewModel(User user)
        {
            MessageService messageService = new MessageService(user);
            Emails = messageService.GetMails();
        }

    }
}
