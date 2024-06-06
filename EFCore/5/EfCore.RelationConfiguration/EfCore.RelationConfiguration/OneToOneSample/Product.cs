using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.OneToOneSample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Discount Discount { get; set; }

    }

    public class Discount
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
    }

    public class OneToOneSampleContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=SimpleConventionDb;Integrated Security = True");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(c =>
            {
                c.HasOne(x => x.Discount).WithOne().HasForeignKey<Discount>(x => x.ProductId);
            });
        }

    }
}
