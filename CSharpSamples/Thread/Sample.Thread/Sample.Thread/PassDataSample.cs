using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Thread
{
    public class PassDataSample
    {
        public void Start()
        {
            System.Threading.Thread twoParameter = new(() => PrintObjectTwoObject("hello","jellooo"));
        }


        public void PrintMethodWithOnlyOneParameter()
        {
            System.Threading.Thread worker = new(PrintObject);
            string hello = "hello world";
            worker.Start(hello);
        }

        /// <summary>
        /// مقدار متغییر شیر شده بین 2 ترد اشکال اشتراک گزاری بین 2 نخ را دارد
        /// </summary>
        public void CaptureVariable()
        {
            string name = "ali";
            System.Threading.Thread a = new(() => Console.WriteLine(name));
            name = "mmd";
            System.Threading.Thread b = new(() => Console.WriteLine(name));
            a.Start();
            b.Start();
        }

        /// <summary>
        /// ترد دارای پارامتر ورودی
        /// </summary>
        /// <param name="input"></param>
        public void PrintObject(object input)
        {
            Console.WriteLine(input.ToString());
        }

        public void PrintObjectTwoObject(object input , object inputTwo)
        {
            Console.WriteLine(input.ToString()+inputTwo.ToString());
        }
    }
}
