using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    public class User
    {
        private string _userName;
        private DateTime _birthday;


        public User(string userName, DateTime birthday)
        {
            _userName = userName;
            _birthday = birthday;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;  }
        }

        public DateTime UserBirthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public int UserAge
        {
            get
            {
                int age = DateTime.Today.Year - _birthday.Year;

                if (DateTime.Today < _birthday.AddYears(age)) // for leap year
                    age--;

                return age;
            }
        }

        //-----------------------------------

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return _userName + " " + _birthday.ToString("d");
        }
    }
}
