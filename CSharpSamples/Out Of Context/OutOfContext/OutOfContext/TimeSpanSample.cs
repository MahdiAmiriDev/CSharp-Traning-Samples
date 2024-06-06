using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfContext
{
    public class TimeSpanSample
    {
        public void Start()
        {

            TimeSpan ts1 = new(1, 30, 10);

            Console.WriteLine("ts one value is {0}", ts1.ToString());

            TimeSpan ts2 = TimeSpan.FromMinutes(1);

            Console.WriteLine("ts from minutes 1 value is:{0}", ts2.ToString());

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddDays(1);

            TimeSpan ts4 = dt1 - dt2;

            Console.WriteLine("defference betweend dt1 and dt2 is {0}", ts4.ToString());

            long ticks = ts1.Ticks;
            double totalMinutes = ts1.TotalMinutes;
            int hours = ts1.Hours;
            TimeSpan duration = ts1.Duration();

            Console.WriteLine("ts2 value betofe add {0}", ts2.ToString());

            ts2 = ts2.Add(ts1);

            Console.WriteLine("ts2 value after add {0}", ts2.ToString());

            int compareTs1AndTs2 = TimeSpan.Compare(ts1, ts2);

            Console.WriteLine("result of compare ts1 and ts2 is {0}", compareTs1AndTs2.ToString());

            bool isEqual = ts1.Equals(ts2);

            Console.WriteLine("is equal ts1 with ts2 vale:{0}", isEqual.ToString());

        }
    }
}
