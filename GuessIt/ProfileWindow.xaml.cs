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
using System.Windows.Shapes;

namespace GuessIt
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        GameServer gameServer;
        public ProfileWindow()
        {
            InitializeComponent();

            gameServer = new GameServer();

            updateInformationAsync();

        }

        private async void updateInformationAsync()
        {
            await Me.updateAsync();
            scoreTextBlock.Text = Me.totalScore.ToString();
            positionTextBlock.Text = Me.position.ToString();
            if (Me.firstName.Length > 0) // show the name if it has been set before
                nameTextBlock.Text = Me.firstName + " " + Me.lastName;

            await Task.Delay(5000);
            updateInformationAsync();
        }
        
        private void controlPanelButton_Click(object sender, RoutedEventArgs e)
        {
            ControlPanelWindow controlPanelWindow = new ControlPanelWindow();
            controlPanelWindow.Show();
            this.Close();
        }
    }
}
