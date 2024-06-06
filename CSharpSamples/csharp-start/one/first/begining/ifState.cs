using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace begining
{
    public class ifState
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// سینتکس جدید برای تست تایپ یا ترو فالس
        /// </summary>
        /// <param name="T"></param>
       public void IsPersong(Object T)
        {
            if(T is Person person) 
            {
                Console.WriteLine($"object is person id is {person.Id }");
            }
            if(T is not Person)
            {
                Console.WriteLine($"not person");
            }
            if (T is true)
            {
                Console.WriteLine("is true");
            }
        }

        public enum color
        {
            red = 1,
            blue = 2,
            green = 3
        }

        public string WriteColorName(int colorId) => colorId switch
        {
            1 => "red",
            2 => "blue",
            3 => "green",
            _ => "not found"
	    };

    }
}
