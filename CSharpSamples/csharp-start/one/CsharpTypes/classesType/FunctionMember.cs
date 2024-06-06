using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal class FunctionMember
    {
        private string name;

        public FunctionMember()
        {
            name = "ali";
        }

        //void method
        public void PrintSomething()
        {
            Console.WriteLine("hello world");
        }


        //-----------------------------------------------------------

        //method with string return
        public string GetMyname()
        {
            string myName = "ali";

            return myName;
        }

        //-----------------------------------------------------------

        /// overloadin method with deffrent signture
        public string GetMyname(string name)
        {
            string myName = name; 

            return myName;
        }
        //-----------------------------------------------------------

        //new syntax for 1 line method with return type
        public string GetName() => name;

        //-----------------------------------------------------------

        //static mehtod in non static class
        public static string myStaticMethod()
        {
            return "i am static method";  
        }
        //-----------------------------------------------------------

        //with name argument method

        public int CalculateSqure(int width , int height)
        {
            return width * height;
        }
        //فراخوانی متد با استفاده از نام ارگومان ها
        public void PrintSqure()
        {
            Console.WriteLine(CalculateSqure(height:23,width:22));
        }

        //پارامتر آپشنال استفاده شده
        public int CalculateOptional(int a , int b , int c = 2 , int d = 3)
        {
            return a * a + c;
        }
        // پارامتر آپشنال را مقدار ندادیم و خطای نداد
        public void TestOptional()
        {
            var x = CalculateOptional(1, 3);

            // می توان پارامتر دلخواه را مقدار داد
            var x2 = CalculateOptional(1, 3,d:4);
        }

        //-----------------------------------------------------------

        // کلمه کلید پارامز
        public void TestParams(params int[] a)
        {

            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
        }

        //------------------------------- constractor -------------------
    }
}
