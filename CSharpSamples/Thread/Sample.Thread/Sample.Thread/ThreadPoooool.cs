using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Thread
{
    public  class ThreadPoooool
    {
        public void StartSimpleThread()
        {
            System.Threading.Thread simple = new(Writer);
            simple.Start();
        }

        public void StartThreadPool()
        {
            Task.Run(() => Writer());
        }

        public void Writer()
        {
            var isBackGround = System.Threading.Thread.CurrentThread.IsBackground;
            var isThPool = System.Threading.Thread.CurrentThread.IsThreadPoolThread;

            Console.WriteLine($"is back:{isBackGround} isPool: {isThPool}");
        }
    }
}
