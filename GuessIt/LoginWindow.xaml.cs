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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace GuessIt
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        GameServer gameServer;
        public LoginWindow()
        {
            InitializeComponent();

            gameServer = new GameServer();

        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            while (!await gameServer.checkInternetConnection())
            {
                await Task.Delay(500);
            }

            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "login", username = usernameTextBox.Text,
                        password = passwordTextBox.Text }).ReceiveString());
                
            Console.WriteLine(loginResponse.ToString());
            if (loginResponse.dataIsRight == "yes")
            {
                Me.id = loginResponse.user.id;
                Me.firstName = loginResponse.user.firstName;
                Me.lastName = loginResponse.user.lastName;
                Me.position = loginResponse.user.position;
                Me.role = loginResponse.user.role;
                Me.scores = loginResponse.user.scores;
                Me.totalScore = loginResponse.user.totalScore;

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }

        }

    }
}
