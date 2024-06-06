using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Sample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SavePersonVm
    {
        [StringLength(23, ErrorMessage ="درست وارد کن گلابی")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ValidationDbContext : DbContext
    {

        public DbSet<Person> People { get; set; }

        public ValidationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(20);
        }

    }
}
