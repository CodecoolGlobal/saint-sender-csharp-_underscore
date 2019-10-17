using System.IO;
using System.Text;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for OpenEmailWindow.xaml
    /// </summary>
    public partial class OpenEmailWindow : Window
    {
        private string encoding = "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
        public OpenEmailWindow(string mainBody)
        {
            InitializeComponent();
            browser.NavigateToString(encoding + mainBody);
          
        }
    }
}
