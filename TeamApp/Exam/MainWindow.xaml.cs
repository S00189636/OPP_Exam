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
        string[] comboArray = { "4-4-2", "4-3-3", "4-5-1" };
        int _spaces = 11;
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
            lstbSelectedPlayers.ItemsSource = _selectedPlayers;
            cboxFormating.ItemsSource = comboArray;
            cboxFormating.SelectedIndex = 0;
            txtbSpaces.Text = _spaces.ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            Player playerToAdd = lstbAllPlayers.SelectedItem as Player;
            // if nothing is selectd do not add anything 
            if (playerToAdd == null) return;
            // if no spaces or the selected player is not valid show the player
            if(_spaces == 0)
            {
                MessageBox.Show("No more spaces", "Adding Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // if the plyer is aready in the formation don't add and show the player 
            else if (!AddToSelected(playerToAdd))
            {
                MessageBox.Show($"You already used all the positions for the type {playerToAdd.PreferredPosition}", "Adding Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            _allPlayers.Remove(playerToAdd);
            // when i add a player space should be decreased
            _spaces--;
            // everytime i add or remove the list are resorted 
            UpdateUIElements();
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            Player playerToRemove = lstbSelectedPlayers.SelectedItem as Player;
            if (playerToRemove == null) return;
            _selectedPlayers.Remove(playerToRemove);
            _allPlayers.Add(playerToRemove);
            // when i remove a player spaceshould be increased
            _spaces++;
            // everytime i add or remove the list are resorted 
            UpdateUIElements();
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
                DOB = new DateTime(random.Next(1990, 2000), random.Next(1,12), random.Next(1,29)),
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


        // this will check if the selected player is a valid selection then add it to the list 
        private bool AddToSelected(Player player)
        {
            // get the formation
            string[] selectedFormation = (cboxFormating.SelectedItem as string).Split('-');
            // get the formation in ints
            int defenders = int.Parse(selectedFormation[0]);
            int Midfielders = int.Parse(selectedFormation[1]);
            int Forwarders = int.Parse(selectedFormation[2]);
            int count;
            switch (player.PreferredPosition)
            {
                case Position.Goalkeeper:
                    count = 1;
                    foreach (Player sPlayer in _selectedPlayers)
                        if (sPlayer.PreferredPosition == Position.Goalkeeper) count--;
                    if (count == 0) return false;
                    break;
                case Position.Defender:
                    count = defenders;
                    foreach (Player sPlayer in _selectedPlayers)
                    {
                        if (sPlayer.PreferredPosition == Position.Defender)
                            count--;
                        if (count == 0) return false;
                    }
                    break;
                case Position.Midfielder:
                    count = Midfielders;
                    foreach (Player sPlayer in _selectedPlayers)
                    {
                        if (sPlayer.PreferredPosition == Position.Midfielder)
                            count--;
                        if (count == 0) return false;
                    }
                    break;
                case Position.Forward:
                    count = Forwarders;
                    foreach (Player sPlayer in _selectedPlayers)
                    {
                        if (sPlayer.PreferredPosition == Position.Forward)
                            count--;
                        if (count == 0) return false;
                    }
                    break;
            }
            _selectedPlayers.Add(player);
            return true;
        }

        // will be called after updates 
        private void UpdateUIElements()
        {
            _allPlayers.Sort();
            _selectedPlayers.Sort();
            txtbSpaces.Text = _spaces.ToString();
        }
    }
}
