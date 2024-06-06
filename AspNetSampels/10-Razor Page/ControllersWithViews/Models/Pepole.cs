using Microsoft.EntityFrameworkCore;

namespace ControllersWithViews.Models
{
    public class Pepole
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PepoleDbContext: DbContext
    {
        public PepoleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pepole> Pepole { get; set; }
    }
}
