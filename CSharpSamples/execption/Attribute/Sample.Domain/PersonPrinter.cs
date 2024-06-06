using AutoScanAttribute;
using System.Diagnostics;

namespace Sample.Domain
{
    [AutoScanDependency]
    public class PersonPrinter
    {
        private readonly Person _person;
        public PersonPrinter(Person person)
        {
            _person = person;
        }

        public void print()
        {
            PrintFullName();
            PrintAge();
        }

        [Obsolete(message:"در ورژن بعدی این کد منقضی می شود")]
        public void PrintAge()
        {
            Console.WriteLine($"age => {_person.Age}");
        }

        private void PrintFullName()
        {
            Console.WriteLine($"full name => {_person.FirstName} , {_person.LastName}");
        }

        /// <summary>
        /// فقط در حالت دیباگ اجرا شود
        /// </summary>
        [Conditional("DEBUG")]
        public void PrintDeveloperName()
        {
            Console.WriteLine("mahdi amiri");
        }
    }
}
