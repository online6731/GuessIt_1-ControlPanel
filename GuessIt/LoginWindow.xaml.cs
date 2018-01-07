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
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic response = await "http://mamadgram.tk/guessIt.php".PostJsonAsync(
                new { action = "login", username = usernameTextBox.Text, password = passwordTextBox.Text }).ReceiveJson();

            if (response.dataIsRight == "yes")
            {
                dynamic user = JsonConvert.DeserializeObject(response.user);
                Me.id = user.id;
                Me.firstName = user.firstName;
                Me.lastName = user.lastName;
                Me.position = user.position;
                Me.role = user.role;
                Me.scores = user.scores;
                Me.totalScore = user.totalScore;
                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
    }
}
