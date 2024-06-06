using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.ManyToMany
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Tag> Tags { get; set; }

    }

    public class Tag
    {
        public int TagId { get; set; } 
        public int ProductId { get; set; }
        public string CommentText { get; set; }

        public List<Product> Products { get; set; }
    }

    public class ProductTags
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }

    public class ManyToManySampleContext : DbContext
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
            c.HasMany(x => x.Tags).WithMany(x => x.Products).UsingEntity<ProductTags>(

                p => p.HasOne(x => x.Tag).WithMany().HasForeignKey(x => x.ProductId),
                T => T.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.TagId)

               );
            });
        }

    }
}
