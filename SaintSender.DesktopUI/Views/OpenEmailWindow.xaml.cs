using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for OpenEmailWindow.xaml
    /// </summary>
    public partial class OpenEmailWindow : Window
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        private readonly MainWindow mainWindow;

        public OpenEmailWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            mainWindow = new MainWindow();
            string strHtml = mainWindowViewModel.emails[mainWindow.messageId].Body;
            browser.NavigateToString(strHtml);
        }
    }
}
