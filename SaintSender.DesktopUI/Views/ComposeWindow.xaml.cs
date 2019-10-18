using SaintSender.DesktopUI.ViewModels;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ComposeWindow : Window
    {
        private readonly ComposeWindowViewModel composeWindowViewModel;

        public ComposeWindow()
        {
            InitializeComponent();
            composeWindowViewModel = new ComposeWindowViewModel();
            this.DataContext = composeWindowViewModel;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (composeWindowViewModel.IsReadyToCancel())
            {
                this.Close();
            }
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            composeWindowViewModel.ComposeMail();
            if (composeWindowViewModel.IsReadyToSend())
            {
                composeWindowViewModel.SendMail();
                this.Close();
            }
        }
    }
}
