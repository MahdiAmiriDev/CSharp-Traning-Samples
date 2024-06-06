using Microsoft.EntityFrameworkCore;

namespace AspShopUi.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
           new Product
           {
               Id = 1,
               Category = "Mobile",
               Name = "apple 13",
               Description = "awsome",
               Price = 1222220000
           },
            new Product
            {
                Id = 2,
                Category = "Mobile",
                Name = "galaxy ultra",
                Description = "good",
                Price = 22400000
            },
        new Product
        {
            Id = 3,
            Category = "Mobile",
            Name = "poco f12",
            Description = "nice",
            Price = 400000
        },
        new Product
        {
            Id = 4,
            Category = "Mobile",
            Name = "hoawi",
            Description = "not bad",
            Price = 550000
        },
                new Product
                {
                    Id = 5,
                    Category = "LapTop",
                    Name = "rog asus",
                    Description = "gaming",
                    Price = 240000000
                },
        new Product
        {
            Id = 6,
            Category = "Laptop",
            Name = "apple",
            Description = "mac book",
            Price = 234440000
        },
                        new Product
                        {
                            Id = 7,
                            Category = "SmartWatch",
                            Name = "apple",
                            Description = "4 inch",
                            Price = 224232
                        },
        new Product
        {
            Id = 8,
            Category = "SmartWatch",
            Name = "galaxyWatch",
            Description = "andriod",
            Price = 233333333
        }

        );
            base.OnModelCreating(modelBuilder);
        }
    }
}
