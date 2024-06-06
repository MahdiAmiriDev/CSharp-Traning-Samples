using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Thread
{
    public class ThreadPrioritty
    {
        /// <summary>
        /// الویت دهی به ترد ها برای اجرای آن ها البته که خیلی نمی توان روی آن حساب کرد
        /// </summary>
        public void Start()
        {
            System.Threading.Thread t = new(() => ThreadPrinter("a"));
            t.Priority = ThreadPriority.Highest;
            System.Threading.Thread t2 = new(() => ThreadPrinter("b"));
            t.Priority = ThreadPriority.Lowest;
            System.Threading.Thread t3 = new(() => ThreadPrinter("c"));

            t.Start();
            t2.Start();
            t3.Start();
        }

        public void ThreadPrinter(string input)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(input);
            }
        }
    }
}
