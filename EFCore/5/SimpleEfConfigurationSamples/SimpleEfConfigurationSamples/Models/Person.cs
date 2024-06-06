using Microsoft.EntityFrameworkCore;
using SimpleEfConfigurationSamples.DataAccessLayer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEfConfigurationSamples.Models
{
    //[EntityTypeConfiguration(typeof(PersonConfig))]
    public  class Person
    { 
        public int PersonId { get; set; }
        public string FirtName { get; private set; }
        public string? LastName { get; set; }
        public bool? IsActive { get; set; }
        public int Age { get; set; }
        public string GetStringAge { get;} 
        //[NotMapped]
        public List<Contact> Contacts { get; set; }

    }
}
