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
        public ProfileWindow()
        {
            InitializeComponent();
            //
        }

        private void prifileWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void nameTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            if (Me.firstName.Length > 0) // show the name if it has been set before
                nameTextBlock.Text = Me.firstName + " " + Me.lastName;
        }

        private void profilePictureImage_Loaded(object sender, RoutedEventArgs e)
        {
            scoreTextBlock.Text = Me.totalScore + " " + " : امتیاز";
        }

        private void controlPanelButton_Click(object sender, RoutedEventArgs e)
        {
            ControlPanelWindow controlPanelWindow = new ControlPanelWindow();
            controlPanelWindow.Show();
            this.Close();
        }
    }
}
