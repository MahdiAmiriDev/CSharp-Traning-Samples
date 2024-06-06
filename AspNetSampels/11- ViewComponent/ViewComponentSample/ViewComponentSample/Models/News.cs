using Microsoft.EntityFrameworkCore;

namespace ViewComponentSample.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }

    public class NewsDbContext:DbContext
    {
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=NewsDb;Integrated Security=true");
        }
    }
}
