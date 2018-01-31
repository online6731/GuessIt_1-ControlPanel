using C1.WPF.C1Chart;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            loadMainManagementPage();

        }

        private async void updateInformationAsync()
        {
            await GameServer.updateAsync();
            numberOfUsersTextBlock.Text = GameServer.numberOfUsers.ToString();
            numberOfGamesTextBlock.Text = GameServer.numberOfGames.ToString();
            numberOfOnlineGamesTextBlock.Text = GameServer.numberOfOnlineGames.ToString();
            numberOfWordsTextBlock.Text = GameServer.numberOfWords.ToString();

            
            numberOfUsersChart.Data.Children.Clear();

            DataSeries ds = new DataSeries();
            ds.Values = new DoubleCollection();
            List<string> items = new List<string>();
            for (int i = 0; i < ServerData.numberOfUsers.Count; i++)
            {
                ds.Values.Add(ServerData.numberOfUsers[i].number);
                items.Add(ServerData.numberOfUsers[i].date);
            }
            numberOfUsersChart.Data.ItemNames = items;
            ds.Label = "کاربران";
            numberOfUsersChart.Data.Children.Add(ds);
            

            await Task.Delay(7000);
            
            updateInformationAsync();
        }

        private async void serverResponseTimeUpdate()
        {
            await GameServer.serverResponseTimeUpdate();
            serverResponseTimeGauge.Value = (int)(1 / GameServer.serverResponseTime);
            //serverTimeTextBlock.Text = GameServer.time;

            await Task.Delay(1000);

            serverResponseTimeUpdate();
        }

        private void setStatus(string status)
        {
            statusTextBlock.Text = status;
        }

        private void loadWordManagementPage()
        {
            wordsDataGrid.ItemsSource = GameServer.words;
            tabControl.SelectedIndex = 1;
        }

        private void loadUsersManagementPage()
        {
            usersDataGrid.ItemsSource = GameServer.users;
            tabControl.SelectedIndex = 3;
        }

        private void loadProjectManagementPage()
        {
            tabControl.SelectedIndex = 2;
        }

        private void loadMainManagementPage()
        {
            tabControl.SelectedIndex = 0;
        }

        private void loadGameManagementPage()
        {
            gamesDataGrid.ItemsSource = GameServer.games;
            tabControl.SelectedIndex = 4;
        }

        private void wordsControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadWordManagementPage();
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
            
            if (await GameServer.addNewWordToDatabase(word) == true)
            {
                setStatus("لغت جدید افزوده شد");
            }
            else
            {
                setStatus("خطا در افزودن لغت جدید");
            }
        }

        private void projectControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadProjectManagementPage();
        }

        private void usersControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadUsersManagementPage();
        }

        private void gamesControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadGameManagementPage();
        }

        private void generalControlButton_Click(object sender, RoutedEventArgs e)
        {
            loadMainManagementPage();
        }
    }
}
