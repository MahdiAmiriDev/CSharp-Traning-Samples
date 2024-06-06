using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Councurency.TaskSamole
{
    public class TaskResultSample
    {
        //دریافت نتجیه تسک
        public void Start()
        {
            Task<int> res = Task.Run(() => Add(20, 30));
            Console.WriteLine(res.Status);
            var sum = res.Result;
            Console.WriteLine( "now have res");
            Console.WriteLine(res.Status);
            Console.WriteLine(sum.ToString());
            Console.WriteLine("finished");
        }

        public int Add(int a ,int b)
        {
            Thread.Sleep(2000);
            return a + b;
        }
    }
}
