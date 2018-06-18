using MahApps.Metro.Controls;
using OMail.Client.MailService;

namespace OMail.Client
{
    public partial class Window4 : MetroWindow
    {
        public Window4(Message message, double leftMainWindow, double topMainWindow, double widthMainWindow)
        {
            InitializeComponent();

            Left = leftMainWindow + widthMainWindow;
            Top = topMainWindow;

            TxtReceivername.Text = message.Receiver.Name;
            TxtSendername.Text = message.Sender.Name;
            TxtSubject.Text = message.Subject;
            TxtSent.Text = message.SendTimeStamp.ToString("HH:mm:ss  dd.MM.yyyy");
            TxtMsgContent.Text = message.Content;
        }
    }
}
