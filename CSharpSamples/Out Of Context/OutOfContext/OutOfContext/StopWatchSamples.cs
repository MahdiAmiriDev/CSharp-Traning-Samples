using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfContext
{
    public class StopWatchSamples
    {
        public void start()
        {
            Console.WriteLine("here we start the stopWatch");

            Stopwatch sw = new();

            sw.Start();

            Thread.Sleep(4000);

            var elapseTime = sw.Elapsed.Seconds;

            sw.Stop();

            Console.WriteLine("my first stopWatch with old syntax elapsed time is {0}", elapseTime.ToString());

            Console.ReadKey();

            Console.WriteLine("now with .net 7 but still not work....");

            long startTime = Stopwatch.GetTimestamp();

            Thread.Sleep(4000);

            //TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            //Console.WriteLine("elapsedTime");
        }
    }
}
