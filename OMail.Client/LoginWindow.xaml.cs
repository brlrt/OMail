using MahApps.Metro.Controls;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace OMail.Client
{
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();

            FocusManager.SetFocusedElement(this, TxtUsername);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var endpoint = new EndpointAddress("http://192.168.178.74:8080/IMailService");
            var client = new MailService.MailServiceClient(new BasicHttpBinding(), endpoint);

            if (TxtUsername.Text == "" || TxtPassword.Password == "")
            {
                LblStatus.Content = "Fill the boxes";
                return;
            }

            if (TxtPassword.Password.Length < 6)
            {
                LblStatus.Content = "Longer password please";
                return;
            }

            if (TxtUsername.Text.Length < 5)
            {
                LblStatus.Content = "Username needs 5 Chars";
                return;
            }

            if (!(CheckboxRegister.IsChecked ?? false))
            {
                if (client.LoginUser(TxtUsername.Text, TxtPassword.Password))
                {
                    new Window2(TxtUsername.Text, TxtPassword.Password, client).Show();
                    Close();
                }
                else
                {
                    LblStatus.Content = "Login failed";
                    LblStatus.ToolTip = "Either your password or username was wrong, please try again. Thanks!";
                    return;
                }
            }
            else
            {
                if (client.RegisterUser(TxtUsername.Text, TxtPassword.Password))
                {
                    new Window2(TxtUsername.Text, TxtPassword.Password, client).Show();
                    Close();
                }
                else
                {
                    LblStatus.Content = "Register failed";
                    LblStatus.ToolTip = "Your wished username already exists, please choose another one. Thanks!";
                    return;
                }
            }
        }
    }
}
