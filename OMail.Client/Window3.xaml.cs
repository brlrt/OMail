using MahApps.Metro.Controls;
using OMail.Client.MailService;
using System;
using System.Windows.Input;

namespace OMail.Client
{
    public partial class Window3 : MetroWindow
    {
        private string senderName;
        private MailServiceClient client;

        public Window3(string senderName, MailServiceClient client, double leftMainWindow, double topMainWindow, double widthMainWindow)
        {
            InitializeComponent();
            Left = leftMainWindow + widthMainWindow;
            Top = topMainWindow;

            this.client = client;
            this.senderName = senderName;
            FocusManager.SetFocusedElement(this, TxtReceiverUsername);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (client.CheckIfUserExists(TxtReceiverUsername.Text))
            {
                var message = new Message
                {
                    Content = TxtMsgContent.Text,
                    Receiver = new User { Name = TxtReceiverUsername.Text },
                    Sender = new User { Name = senderName },
                    SendTimeStamp = DateTime.Now,
                    Subject = TxtSubject.Text,
                };

                client.SendMessage(message);
                Close();
            }
            else
            {
                LblStatus.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
