using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance.Selaed
{
    public class Person
    {
        public int Number { get; set; } = 09828723;
        public string Name { get; set; } = "ali";
        public string LastNmae { get; set; } = "abbasi";
    }

    public sealed class Teacher
    {
        Person p = new();

        public void Write()
        {
            Console.WriteLine($"{p.Name}");
        }
    }
    /// <summary>
    /// خطا می دهد چون نمی تواند از سیلد ارث ببرد
    /// </summary>
    //public class Student : Teacher
    //{

    //}
}
