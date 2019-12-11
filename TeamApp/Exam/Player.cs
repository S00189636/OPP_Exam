using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Player : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get { return DateTime.Now.Subtract(DOB).Days / 365; } }
        public Position PreferredPosition { get; set; }


        // used for sorting
        public int CompareTo(object obj)
        {
            Player tempPlayer = obj as Player;

            if (this.PreferredPosition.CompareTo(tempPlayer.PreferredPosition) == 0)
                return this.FirstName.CompareTo(tempPlayer.FirstName);
            else return this.PreferredPosition.CompareTo(tempPlayer.PreferredPosition);
        }


        // this will be used to show the plyer im the list box item
        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName} ({Age}) - {PreferredPosition}");
        }
    }
}
