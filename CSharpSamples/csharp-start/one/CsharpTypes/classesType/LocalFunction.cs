 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal class LocalFunction
    {
        private List<int> intList;

        public LocalFunction(List<int> numbers)
        {
            //new syntax
            if (numbers is null)
            {
                numbers.Add(0);
            }
        }

        //استفاده از متد داخلی درون همدیگر
        public void myLocalFunction()
        {
            string name = "ali";
            string family = "amiri";

            var fullName = GetMyName();            

            string GetMyName()
            {
                return $"{name} , {family}";
            }
        }
    }
}
