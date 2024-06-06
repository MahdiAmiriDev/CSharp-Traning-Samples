using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        [BindNever]
        public string Name { get; set; }
    }

    public class MyMbDbContext : DbContext
    {
        public MyMbDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}
