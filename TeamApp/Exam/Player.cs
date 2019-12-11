using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get { return DateTime.Now.Subtract(DOB).Days / 365; } }
        public Position PreferredPosition { get; set; }
    }
}
