using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class PersonPrinter
    {
        public void Print(PersonToString personToString, Person person)
        {
            string s = personToString(person);
            Console.WriteLine(s);
        }

        public void PrintWithFunc(Person person)
        {
            //string s = personToString(person);
            //Console.WriteLine(s);
        }
    }
}
