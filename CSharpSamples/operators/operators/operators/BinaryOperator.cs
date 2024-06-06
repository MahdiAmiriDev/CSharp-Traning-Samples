using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operators
{
    public class BinaryOperator
    {
        public void And()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);
            var c = a & b;
            Console.WriteLine(c);
        }

        public void Or()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);
            var c = a | b;
            Console.WriteLine(c);
        }

        public void Xor()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);
            var c = a ^ b;
            Console.WriteLine(c);
        }

        public void Reverse()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);
            var c = ~b;
            Console.WriteLine(c);
        }

        public void Shift()
        {
            var a = 0b1;

            Console.WriteLine(a);

            var c = a << 1;
            var d = a << 2;
            var g = a << 4;
            var b = a << 5;

            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(g);
            Console.WriteLine(b);
        }
    }
}
