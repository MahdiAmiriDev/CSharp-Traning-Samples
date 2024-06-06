using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SetSample
    {
        HashSet<string> set = new();

        public void Mehtods()
        {
            set.UnionWith(set);
            set.ExceptWith(set);
            set.Add("ss");
            set.IsSubsetOf(set);
        }
    }
}
