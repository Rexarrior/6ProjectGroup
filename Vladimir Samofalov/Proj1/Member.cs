using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proj1
{
    class Member
    {
        string number;
        string firstName;
        string lastName;
        string info;
        public void isOk() 
        {
            if(number!=""&&firstName!=""&&lastName!=""&&!Properties.Settings.Default.fail)
            {
                Properties.Settings.Default.IsOk = true;
            }
            else
            {
                Properties.Settings.Default.IsOk = false;
            }
        }
        public Member()
        {
            number = "";
            firstName = "";
            lastName = "";
            info = "";
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == "" ) 
                {
                    MessageBox.Show("Имя не может быть пустым ");
                    Properties.Settings.Default.fail = true;
                }
                else
                {
                    firstName = value;
                    isOk();
                }
                
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == "" )
                {
                    MessageBox.Show("Фамилия не может быть пустой ");
                    Properties.Settings.Default.fail = true;
                }
                else
                {
                    lastName = value;
                    isOk();
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                Regex rg = new Regex(@"(^\d+$|^\+\d+$)");
                if (value == "" || !rg.IsMatch(value))
                {
                    MessageBox.Show("Номер телефона может содержать только цифры и не может быть пустым");
                    Properties.Settings.Default.fail = true;
                }
                else
                {                           // I suggest to set the fail flag to false there.  R.
                    number = value;
                    isOk();
                }
            }
        }
        public string Info { get; set; }
        public override string ToString()
        {
            return firstName + " " + lastName + "  " + number;
        }
    }
}
