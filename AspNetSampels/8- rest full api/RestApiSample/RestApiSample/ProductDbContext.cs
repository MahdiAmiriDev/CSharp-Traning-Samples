using Microsoft.EntityFrameworkCore;

namespace RestApiSample
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ApiDb;Integrated Security= true");
        }
    }
}
