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

        public Window3(string username, MailServiceClient client)
        {
            InitializeComponent();

            this.client = client;
            this.senderName = username;
            FocusManager.SetFocusedElement(this, TxtReceiverUsername);
        }

        //Responds to the message
        public Window3(string senderName, MailServiceClient client, Message message)
        {
            InitializeComponent();

            this.client = client;
            this.senderName = senderName;

            TxtReceiverUsername.Text = message.Sender.Name;
            TxtSubject.Text = "RE: " + message.Subject;
        }

        //Send Message again
        public Window3(string senderName, MailServiceClient client, Message message, bool sendMessageAgain)
        {
            InitializeComponent();

            this.client = client;
            this.senderName = senderName;

            TxtReceiverUsername.Text = message.Receiver.Name;
            TxtSubject.Text = message.Subject;
            TxtMsgContent.Text = message.Content;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (client.CheckIfUserExists(TxtReceiverUsername.Text))
            {
                var message = new Message
                {
                    Content = TxtMsgContent.Text,
                    Receiver = new User { Name = TxtReceiverUsername.Text },
                    Sender = new User { Name = senderName},
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
