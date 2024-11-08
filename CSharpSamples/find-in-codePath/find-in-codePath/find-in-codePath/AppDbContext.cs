using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_in_codePath
{
    public class AppDbContext: DbContext
    {
        public DbSet<Company> MyProperty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog= CompanyCodePath;Integrated Security = True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>()
                .HasData(new Company { Id = 1, CodePath = ",120,121,122,123," },
                new Company { Id = 2, CodePath = ",1120,1121,1122,1123," },
                new Company { Id = 3, CodePath = ",2120,2121,2122,2123," });

            base.OnModelCreating(modelBuilder);
        }
    }
}
