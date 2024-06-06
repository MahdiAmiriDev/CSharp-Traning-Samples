using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance.Animal
{
    public class Animal
    {
        public virtual void Voice()
        {
            Console.WriteLine("parent voice");
        }
    }

    /// <summary>
    /// این کلاس از انیمال ارث بری کرده و برای کلاس سگ صدا را اورراید کرده در واقع استفاده از چند ریختی
    /// به این صورت که برای هر کلاس می تواند صدای متقاوتی داشته باشد
    /// </summary>
    ///    
    public class Dog : Animal
    {
        public override void Voice()
        {
            Console.WriteLine("overriden mehtod  dog");
            base.Voice();
            
        }
    }


    public class Cat : Animal
    {
        public override void Voice()
        {
            Console.WriteLine("overriden mehtod cat");
            base.Voice();

        }
    }
}
