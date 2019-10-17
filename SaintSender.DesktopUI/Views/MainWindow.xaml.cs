using System.Windows;
using System.Windows.Input;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
        }

        private void lbi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEmailWindow win = new OpenEmailWindow(mainWindowViewModel.selectedEmail.Body);
            win.Show();
        }
    }
}
