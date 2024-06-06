using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Thread
{
    public class ForeGroundBackGroundT
    {
        /// <summary>
        /// ترد که از نوع بک گراند است از بین می رود سریع که با دستور جوین زنده نگه داشته ایم آن را
        /// و محدودیت زمانی 3 ثاینه برای زنده ماندنش دادیم
        /// </summary>
        public void Start()
        {
            System.Threading.Thread t = new(PrintAndRead);
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("main thread finish");
            t.Join(TimeSpan.FromSeconds(3));
        }

        public void PrintAndRead()
        {
            Console.WriteLine("please enter a word");
            Console.ReadLine();
        }
    }
}
