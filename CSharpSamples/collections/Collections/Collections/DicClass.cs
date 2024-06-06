using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class DicClass
    {
        Dictionary<string, string> dictionary = new();

        public void Add(string key , string value)
        {
            dictionary.Add(key , value);
            dictionary[key] = value;
        }

        public void Print()
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Value+" "+item.Key);

                Console.WriteLine(dictionary[item.Key]);
            }            
        }

        public void Start()
        {
            Add("1", "q");
            Add("2", "w");
            Add("3", "t");
            Add("4", "t");
            Add("5", "h");

            Print();
        }
    }
}
