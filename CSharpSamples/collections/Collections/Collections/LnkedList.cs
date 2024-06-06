using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LnkedList
    {
        LinkedList<string> list = new();

        public void AddToList(string input)
        {
            list.AddFirst(input);
        }

        public void Start()
        {
            AddToList("one");
            AddToList("two");
            AddToList("3");
            AddToList("4");

            var t = list;

            var f = list.First;
            if(!string.IsNullOrEmpty(f.Value))
            list.AddAfter(f, "54");
        }
    }
}
