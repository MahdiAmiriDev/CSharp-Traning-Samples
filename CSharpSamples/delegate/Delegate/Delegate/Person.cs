using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /// <summary>
    /// ساختن دلیگیت
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public delegate string PersonToString(Person person);

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class PersonFullName
    {
        /// <summary>
        /// این متد را با امضای مشابه دیلیگیت ساختیم تا بعدا اساین شود به هم
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static string GetPersonFullName(Person person) => $"{person.FirstName} {person.LastName}";       
    }

    public class PersonFullNameReverse
    {       
        public static string GetPersonFullNameReverse(Person person) => $" {person.LastName}  {person.FirstName}";
    }

    /// <summary>
    /// دلیگیت برای حالت func
    /// </summary>
    public class FuncDelegate
    {
        public static string GetFullNameTest(int i ,int b , int c) => $"{i} {b} {c}";
    }

    /// <summary>
    /// مثال متد به روش ناشنسان آنونیماس
    /// </summary>
    public class AnonemousMethod
    {

        public void WriteAnonymousMethod()
        {
            Person person = new()
            {
                FirstName = "mmd",
                LastName = "shafaei"
            };

            PersonToString myDelegate = delegate (Person person)
            {
                return $"{person.FirstName} {person.LastName}";
            };

            var res = myDelegate(person);
            Console.WriteLine(res);
        }
    }

    /// <summary>
    /// لامدا اکسپرشن در سی شارپ
    /// </summary>
    public class LamdaMethod
    {
        public void TestLamda()
        {
           Func<int ,int , string> TestLamda = (x,y) => x.ToString()+y.ToString();

            Console.WriteLine(TestLamda(1,4));
        }
    }
}
