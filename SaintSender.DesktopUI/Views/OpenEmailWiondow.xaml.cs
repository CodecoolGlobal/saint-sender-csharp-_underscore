using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    public partial class OpenEmailWindow : Window
    {
        private string encoding = "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
        public OpenEmailWindow(string mainBody, string from, string subject)
        {
            InitializeComponent();
            browser.NavigateToString(encoding + mainBody);
            From.Text = from;
            Subject.Text = subject;
        }

    }
}