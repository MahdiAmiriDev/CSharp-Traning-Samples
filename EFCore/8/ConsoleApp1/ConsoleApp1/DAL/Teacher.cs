using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public class Teacher: System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int id;

        public int Id
        {
            get { return id; }
            set 
            { 

                id = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));

            }
        }

        private string firstName;

        public string FistName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FistName)));
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set 
            {
                lastName = value; 
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(LastName)));
            }
        }


    }
}
