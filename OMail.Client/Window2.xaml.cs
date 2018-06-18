using MahApps.Metro.Controls;
using OMail.Client.MailService;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OMail.Client
{
    public partial class Window2 : MetroWindow
    {
        private MailServiceClient client;
        private string username;
        private string password;

        public Window2(string username, string password, MailServiceClient client)
        {
            InitializeComponent();

            this.client = client;
            this.username = username;
            this.password = password;

            var rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(MouseDoubleClickEvent, new MouseButtonEventHandler(Row_DoubleClick)));
            DatagridInboxMessages.RowStyle = rowStyle;
            DataGridOutboxMessages.RowStyle = rowStyle;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            new Window3(username, client, Left, Top, Width).Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (((sender as TabControl).SelectedItem as TabItem).IsSelected)
                {
                    string tabItem = ((sender as TabControl).SelectedItem as TabItem)
                                        .Header as string;

                    switch (tabItem)
                    {
                        case "Inbox":
                            LoadMsgsIntoInboxDataGrid();
                            break;
                        case "Outbox":
                            LoadMsgsIntoOutboxDataGrid();
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        private void LoadMsgsIntoOutboxDataGrid()
        {
            DataGridOutboxMessages.ItemsSource = client.GetSendedMessages(username).ToList();
            DataGridOutboxMessages.Items.Refresh();
        }

        private void LoadMsgsIntoInboxDataGrid()
        {
            DatagridInboxMessages.ItemsSource = client.GetReceivedMessages(username).ToList();
            DataGridOutboxMessages.Items.Refresh();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var message = (sender as DataGridRow).Item as Message;

            new Window4(message, Left, Top, Width).Show();
        }
    }
}
