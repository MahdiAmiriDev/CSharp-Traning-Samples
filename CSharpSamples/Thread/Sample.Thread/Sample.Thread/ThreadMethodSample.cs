using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Thread
{
    public class ThreadMethodSample
    {
        /// <summary>
        /// استفاده ساده از ترد و اجرای هم زمان
        /// </summary>
        public void ThreadSample()
        {
            CharPrinter cp = new();

            System.Threading.Thread dashWorker = new(cp.PrintDash);
            dashWorker.Name = "myThread";
            dashWorker.Start();
            cp.PrintStar();
            Console.WriteLine(dashWorker.IsAlive + " name" + $"{dashWorker.Name}");
            //cp.PrintDash();
        }
        /// <summary>
        /// انتظار برای پایان یک ترد و سپس اجرای ترد دوم یا کار دوم
        /// </summary>
        public void JoinSample()
        {
            CharPrinter cp = new();
            System.Threading.Thread dashWorker = new(cp.PrintDash);
            dashWorker.Start();
            dashWorker.Join();
            //dashWorker.Join(TimeSpan.FromSeconds(2));
            dashWorker.Join();
            cp.PrintStar();

        }
        //توقف ترد برای بازه زمانی و اجرای مجدد آن
        public void Sleep()
        {
            CharPrinter cp = new();
            System.Threading.Thread dashWorker = new(cp.PrintDash);
            dashWorker.Start();
            System.Threading.Thread.Sleep(50);
            cp.PrintStar();
        }
        // یک ترد را به طور کامل متوقف می کند و فرآیند اجرا را به ترد دیگری می دهد
        public void Yeild()
        {
            CharPrinter cp = new();
            System.Threading.Thread dashWorker = new(cp.PrintDash);
            dashWorker.Start();           
            cp.PrintStar();
        }
        /// <summary>
        /// برسی وضعیت ترد
        /// </summary>
        public void ThreadStateCheck()
        {
            CharPrinter cp = new();
            System.Threading.Thread dashWorker = new(cp.PrintDash);
            dashWorker.Start();
            Console.WriteLine(dashWorker.ThreadState);
        }
    }
}
