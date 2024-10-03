using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    public class TestDelegate
    {
        public delegate void PrintSomeTextInConsole();

        public delegate void GetStringAndPrintIt(string text);

        public PrintSomeTextInConsole test;

        public TestDelegate(PrintSomeTextInConsole myDelegate)
        {
            test = myDelegate;
        }

        public void CallSendedDelegate()
        {
            test();
        }

        GetStringAndPrintIt text = (string hi) =>
        {
            Console.WriteLine(hi);
        };

        void Print(GetStringAndPrintIt d)
        {
            d("this is a delegate");
        }

        
    }
}
