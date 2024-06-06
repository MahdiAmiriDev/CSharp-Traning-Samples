using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{

    interface IAuditDate
    {
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }

    public class Student : IAuditDate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
