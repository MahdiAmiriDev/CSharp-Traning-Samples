using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SortedList
    {
        SortedList<int, string> list = new();

        public void Add(int key , string value)
        {
            list.Add(key, value);
        }


        public void Start()
        {
            Add(1, "yek");
            Add(2, "do");
            Add(4, "se");
            Add(5, "char");
        }
    }
}
