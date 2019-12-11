using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public static class MyExtensions
    {
        // this will add the sort method to all list ObservableCollection 
        // it will copy the list to a normal list sort it and copy it back 
        public static void Sort(this ObservableCollection<Player> listToSort)
        {
            List<Player> sortedlist = new List<Player>();
            foreach (Player player in listToSort)
                sortedlist.Add(player);
            listToSort.Clear();
            sortedlist.Sort();
            foreach (Player player in sortedlist)
                listToSort.Add(player);
        }
    }
}
