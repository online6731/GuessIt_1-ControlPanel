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

            await Task.Delay(1000);

            serverResponseTimeUpdate();
        }

        private void setStatus(string status)
        {
            statusTextBlock.Text = status;
        }

        private void loadWordManagement()
        {
            wordsDataGrid.ItemsSource = GameInformation.words;
            tabControl.SelectedIndex = 1;
        }
        private void wordsControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadWordManagement();
        }

        private async void addNewWordButton_Click(object sender, RoutedEventArgs e)
        {
            setStatus("در حال افزودن لغت جدید ...");
            string completeWord = completeWordTextbox.Text;
            string incompleteWord = incompleteWordTextbox.Text;
            string category = categoryTextbox.Text;
            Word word = new Word()
            {
                word = completeWord,
                category = category,
                incompleteWord = incompleteWord
            };
            
            if (await GameInformation.addNewWordToDatabase(word) == true)
            {
                setStatus("لغت جدید افزوده شد");
            }
            else
            {
                setStatus("خطا در افزودن لغت جدید");
            }
        }
    }
}
