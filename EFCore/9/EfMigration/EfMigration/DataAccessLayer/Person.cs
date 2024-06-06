using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfMigration.DataAccessLayer
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SBIN { get; set; }
    }
}
