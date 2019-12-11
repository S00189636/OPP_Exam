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
            _allPlayers = new ObservableCollection<Player>();
            _selectedPlayers = new ObservableCollection<Player>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // when the main window is loadded creat the players
            CreatPlayers();
            lstbAllPlayers.ItemsSource = _allPlayers;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        // will use the position to creat a new player
        private Player CreatRandomPlayer(Position position)
        {
            // will use torandom the name 
            string[] firstnames = {"Liam","Noah","William","James","Oliver","Benjamin","Elijah","Lucas" };
            // retrun a new created player with random values 
            return new Player()
            {
                FirstName = firstnames[random.Next(0, firstnames.Length)],
                LastName = firstnames[random.Next(0, firstnames.Length)],
                DOB = new DateTime(random.Next(1990, 2000), random.Next(30), random.Next(12)),
                PreferredPosition = position
            };

        }
        // this will creat 18 players 
        // 2 GK ,6D,6M,4F
        private void CreatPlayers()
        {
            for (int i = 0; i < 2; i++)
                _allPlayers.Add(CreatRandomPlayer(Position.Goalkeeper));
            for (int i = 0; i < 6; i++)
                _allPlayers.Add(CreatRandomPlayer(Position.Midfielder));
            for (int i = 0; i < 6; i++)
                _allPlayers.Add(CreatRandomPlayer(Position.Defender));
            for (int i = 0; i < 4; i++)
                _allPlayers.Add(CreatRandomPlayer(Position.Forward));
        }
    }
}
