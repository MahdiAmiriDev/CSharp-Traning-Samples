using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void WriteMethodName();
    public class MethodNamePrinter
    {

         public void MethodName1()
        {
            Console.WriteLine(nameof(MethodName1));
        }
         public void MethodName2()
        {
            Console.WriteLine(nameof(MethodName2));
        }

        public void MethodName3()
        {
            Console.WriteLine(nameof(MethodName3));
        }
    }
}
