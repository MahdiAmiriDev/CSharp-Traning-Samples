using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.OneToMany
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Comment> Comments { get; set; }

    }

    public class Comment
    {
        public int CommentId { get; set; } 
        public int ProductId { get; set; }
        public string CommentText { get; set; }
    }

    public class OneToManySampleContext : DbContext
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
                c.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.ProductId);
            });
        }

    }
}
