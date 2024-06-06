using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Councurency.TaskSamole
{
    public class ContinueSample
    {
        //روش قدیمی که صبر میکنه برای نتجیه و به خط بعدی نمی رود
        public void Start()
        {
            Task<int> sumRes = Task.Run(() => sum(100, 200));
            sumRes.Wait();
            Console.WriteLine("res is "+sumRes.Result);
            Console.WriteLine("finish");
        }

        public void NewMethodStart()
        {
            Task<int> sumRes = Task.Run(() => sum(100, 200));

            var awaiter = sumRes.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
   
                Console.WriteLine("result is " + awaiter.GetResult());
            });


            Console.WriteLine("finished");
            Console.ReadLine();
        }

        public void Startttt()
        {
            Task<int> sumRes = Task.Run(() => sum(100, 200));
            sumRes.ContinueWith(x => Console.WriteLine("after sum res" + x.Result));
            Console.ReadLine();

        }


        public int sum(int a , int b)
        {
            Thread.Sleep(1000);
            return a + b;
        }
    }
}
