using Microsoft.EntityFrameworkCore;

namespace EfMigration.DataAccessLayer
{
    public class PersonDbContext : DbContext
    {
        //public DbSet<Person> People { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=migratinDb;integrated security=true;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //جلوگیری از ایحاد مدل در فرآیند ایجاد دیتا بیس
        //    modelBuilder.Entity<Book>().ToTable("Books", c => c.ExcludeFromMigrations());
        //}
    }

}
