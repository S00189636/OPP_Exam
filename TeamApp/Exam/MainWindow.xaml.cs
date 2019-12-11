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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // used in creating random player
        ObservableCollection<Player> _allPlayers;
        ObservableCollection<Player> _selectedPlayers;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {

        }


        private Player CreatRandomPlayer()
        {
            string[] firstnames = {"Liam","Noah","William","James","Oliver","Benjamin","Elijah","Lucas" };
            string[] lastNames = {"Liam","Noah","William","James","Oliver","Benjamin","Elijah","Lucas" };
            return new Player()
            {
                FirstName = firstnames[random.Next(0, firstnames.Length)],
                LastName = firstnames[random.Next(0, firstnames.Length)],
                DOB = new DateTime(random.Next(1990, 2000), random.Next(30), random.Next(12)),
                PreferredPosition = (Position) random.Next(3)
            };

        }




    }
}
