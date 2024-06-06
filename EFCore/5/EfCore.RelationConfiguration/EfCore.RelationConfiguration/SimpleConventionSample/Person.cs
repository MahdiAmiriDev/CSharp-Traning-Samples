using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace EfCore.RelationConfiguration.SimpleConventionSample
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        //ارتباط الو نال   غیر اجباری
        // public int? PersonId { get; set; }


        //معرفی کلید خارجی با دیتا انوتیشن
        //[ForeignKey("Person")]
        //public int PFk { get; set; }

    }
}
