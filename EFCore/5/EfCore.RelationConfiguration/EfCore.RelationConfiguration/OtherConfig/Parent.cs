using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.OtherConfig
{
    public class Parent
    {
        public int ParentId { get; set; }
        public String Name { get; set; }

        public List<Child> Children { get; set; }
    }

    public class Child
    {
        public int ChildId { get; set; }
        public string ChildName { get; set; }
    }

    public class otherDbcontext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>(x =>
            {
                //x.HasMany(x => x.Children).WithOne().OnDelete(DeleteBehavior.Cascade);
                //کلید صلی
                //x.HasMany(x => x.Children).WithOne().HasPrincipalKey(x => x.ParentId);

            });
        }
    }
}
