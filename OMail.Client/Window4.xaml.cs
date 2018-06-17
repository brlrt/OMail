using MahApps.Metro.Controls;
using OMail.Client.MailService;
using System.Globalization;

namespace OMail.Client
{
    public partial class Window4 : MetroWindow
    {
        private Message message;
        private MailServiceClient client;

        private bool userWasSender;

        public Window4(Message message, MailServiceClient client, bool userWasSender)
        {
            InitializeComponent();

            this.userWasSender = userWasSender;
            this.client = client;
            this.message = message;

            if (userWasSender)
            {
                BtnRespond.Content = "Send again";
                Txt1.Text = "To:";
            }
            else
            {
                BtnRespond.Content = "Respond";
            }

            TxtFrom.Text = message.Sender.Name;
            TxtSubject.Text = message.Subject;
            TxtDateReceived.Text = message.SendTimeStamp.ToString("HH:mm  dd.MM.yyyy", CultureInfo.InvariantCulture);
            TxtMsgContent.Text = message.Content;
        }

        private void BtnRespond_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (userWasSender)
            {
                new Window3(message.Sender.Name, client, message, true).Show();
            }
            else
            {
                new Window3(message.Receiver.Name, client, message).Show();
            }
            Close();
        }
    }
}
