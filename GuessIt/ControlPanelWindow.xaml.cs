using Flurl.Http;
using Newtonsoft.Json;
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
    /// Interaction logic for ControlPanelWindow.xaml
    /// </summary>
    public partial class ControlPanelWindow : Window
    {
        public ControlPanelWindow()
        {
            InitializeComponent();

            updateInformationAsync();

            serverResponseTimeUpdate();

        }
        private async void updateInformationAsync()
        {
            await GameInformation.updateAsync();
            numberOfUsersTextBlock.Text = GameInformation.numberOfUsers.ToString();
            numberOfGamesTextBlock.Text = GameInformation.numberOfGames.ToString();
            numberOfOnlineGamesTextBlock.Text = GameInformation.numberOfOnlineGames.ToString();
            numberOfWordsTextBlock.Text = GameInformation.numberOfWords.ToString();

            await Task.Delay(5000);
            
            updateInformationAsync();
        }

        private async void serverResponseTimeUpdate()
        {
            await GameInformation.serverResponseTimeUpdate();
            serverResponseTimeGauge.Value = GameInformation.serverResponseTime * 10;

            await Task.Delay(100);

            serverResponseTimeUpdate();
        }

        private void wordsControlButton_Click(object sender, RoutedEventArgs e)
        {
            WordsManagementWindow wordsManagementWindow = new WordsManagementWindow();
            wordsManagementWindow.Show();
        }
    }
}
