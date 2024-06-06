using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance.Constractor
{
    public class Product
    {
        public Product()
        {
            Console.WriteLine("ctor without parameter");
        }

        public Product(string model)
        {
            Console.WriteLine($"the parent ctor model is {model}");
        }
    }

    public class Mobile:Product
    {
        public Mobile():base()
        {
            Console.WriteLine("child with out parameter");
        }

        public Mobile(string model):base(model)
        {
            Console.WriteLine($"child with model {model}");
        }
    }
}
