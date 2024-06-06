using ConsoleApp1.InterCeptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{

    public class MyDbContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.;Initial Catalog=SampleDbContext;Integrated Security=true")
                .AddInterceptors(new CustomInterCeptors());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
        }

        public override int SaveChanges()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            AddAuditDate();
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        private void AddAuditDate()
        {
            ChangeTracker.DetectChanges();

            var added = ChangeTracker.Entries<IAuditDate>().Where(x => x.State == EntityState.Added).ToList();

            foreach (var item in added)
            {
                item.Property(x => x.CreationDate).CurrentValue = DateTime.Now;
            }

            var modified = ChangeTracker.Entries<IAuditDate>().Where(x => x.State == EntityState.Modified).ToList();

            foreach(var item in modified)
            {
                item.Property(x => x.ModificationDate).CurrentValue = DateTime.Now;
            }
         }
    }
}
