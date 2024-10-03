using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DelegateSample
{
    public class SecondDelegateSample
    {
        delegate double CalculateArea(int r);

        public delegate void CallBack(int i);

        public delegate void CallBackVoid();

        CalculateArea variable;

        //Func Generic Delegate
        Func<int, int, int> sum = (num1, num2) => num1 + num2; 

        public SecondDelegateSample()
        {
            //with method
            variable = CalcArea;

            //lamda ex
            variable = (x) => 3.12;
        }

        public double CalcArea(int r)
        {
            var result = 3.14 * (r * r);
            Console.WriteLine(result);
            return result;
        }

        public void InvokeDelegate(int number)
        {
            //send to mehtod
            variable(number);
        }

        public void InvokeLamda(int number)
        {
            //witg lamda
            var res = variable(number);
            Console.WriteLine(res);
        }

        public void CallFuncGenericDelegate(int num1 , int num2)
        {
            Console.WriteLine(sum(num1,num2));
        }

        public void TestFunGenericDelegte(Func<int, int> func , int value)
        {
            Console.WriteLine(func(value));
        }

        //فراخوانی متد تستی
        //از بیرون مشخص کردم که دلیکیت دریافتی قراره چیکار کنه
        //و مقدار دلخواه را براش ارسال کردم و اون هم چیزی که دادم را اجرا کرد
        public void CallTestGenericDelegate()
        {
            Func<int, int> func = (x) => x * 2;
            TestFunGenericDelegte(func, 134);
        }

        public void PrintWithAction(Action<string> action,string value)
        {

            action = x => Console.WriteLine(x);
            action = value => Console.WriteLine(value);
            
        }

        //بررسی صحت یک عبارت کاربرد دارد
        public void PridicateTest(Predicate<string> predicate,string value)
        {            
            Console.WriteLine(predicate(value));
        }


        public void ExpressionTreeSample()
        {
            var v1 = Expression.MakeBinary(ExpressionType.Add,Expression.Constant(2),Expression.Constant(3));
            var v2 = Expression.MakeBinary(ExpressionType.Add,Expression.Constant(4),Expression.Constant(5));
            var v3 = Expression.MakeBinary(ExpressionType.Subtract,v1,v2);

            int result2 = Expression.Lambda<Func<int>>(v3).Compile()();            
            Console.WriteLine(result2);
        }


        public void CallBackDelegate(CallBack obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                obj(i);
            }
        }

        public void CallBackDelegateVoid(CallBackVoid obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                obj();
            }
        }
    }
}
