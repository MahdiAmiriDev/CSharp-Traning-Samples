using Microsoft.EntityFrameworkCore;

namespace EfCore.RelationConfiguration.SimpleConventionSample
{
    public class SimpleConventionSampleContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=SimpleConventionDb;Integrated Security = True");


        }

    }
}
