using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool LoggedIn { get; set; }

        private readonly MainWindowViewModel mainWindowViewModel;

        public MainWindow(User user)
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel(user);
            this.DataContext = mainWindowViewModel;
        }

        private void lbi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEmailWindow win = new OpenEmailWindow(mainWindowViewModel.selectedEmail.Body,
                                                      mainWindowViewModel.selectedEmail.From,
                                                      mainWindowViewModel.selectedEmail.Subject);
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComposeWindow composeWindow = new ComposeWindow();
            composeWindow.Show();
        }
    }
}