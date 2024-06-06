using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesType
{
    internal class ConstractorSample
    {
        private readonly int age;
        //صدا زدن سازنده دوم در اولی با استفاده از کلمه کلیدی دیس
        public ConstractorSample():this(5)
        {
            
        }

        public ConstractorSample(int age)
        {
            this.age = age;
        }
    }
}
