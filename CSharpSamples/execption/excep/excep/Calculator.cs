using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excep
{
    public class Calculator
    {

        /// <summary>
        /// گرفتن خطا
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public void Add(int a, int b)
        {
            if (a < 1)
                throw new ArgumentException();
            if (b < 1)
                throw new Exception();

            Console.WriteLine(a + b);
        }


        public void AddWithCustomExecption(int a, int b)
        {
            if (a < 1)
                throw new MyCustomException();

            if (b < 1)
                throw new MyCustomException();


            Console.WriteLine(a + b);
        }

        /// <summary>
        /// کدی که احتمال خطا دارد را چک می کنیم
        /// </summary>
        public void Start()
        {
            Add(1, 3);
            try
            {
                Add(2, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //--------------------------------------------------------------
            //پرتاب اکسپشن کاستوم شده
            AddWithCustomExecption(1, 3);
            try
            {
                AddWithCustomExecption(2, 0);
            }
            catch (MyCustomException e)
            {

                Console.WriteLine(e.DefaultErrorMessage.ToString());

            }
        }
    }
}
