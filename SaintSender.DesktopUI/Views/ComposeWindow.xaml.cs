using SaintSender.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            //messagebox discard mail
            this.Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            composeWindowViewModel.CopmoseMail();
            if (composeWindowViewModel.IsReadyToSend())
            {
                composeWindowViewModel.Send();
                this.Close();
            }
        }
    }
}
