using Microsoft.EntityFrameworkCore;
using SimpleEfConfigurationSamples.Models;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    public class ConfigSampleContext:DbContext
    {
        public DbSet<Person> People { get; set;}
        public DbSet<Teacher> Teachers { get; set;}
        public DbSet<TypeAndNameWithAttribute> TypeAndNameWithAttributes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PrimaryKeyAttribute> PrimaryKeyAttributes { get; set; }
        public DbSet<PrimaryKeyFlent> PrimaryKeyFlents { get; set; }
        public DbSet<ReadOnlyAttributes> ReadOnlyAttributes { get; set; }
        public DbSet<ReadOnlyFluent> ReadOnlyFluents { get; set; }
        public DbSet<IndexUsingAttributes> IndexUsingAttributes { get; set; }
        public DbSet<IndexUsingFluent> IndexUsingFluents { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<News> News { get; set; }                                           

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog =ConfigSampleDb;Integrated Security =true");
        }
        /// <summary>
        /// کانفیگ هنگام ساخت دی بی 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////پروپرتی کانتکت را برای انتیتی پرسن در نظر نگیر 
            //modelBuilder.Entity<Person>().Ignore(c => c.Contacts);
            ////کلا این اینتیتی را ایگنور کن
            // modelBuilder.Ignore<Contact>();
            ////خواندن کانفیگ های انتیتی از کلاس کانفیگ مخصوص
            //modelBuilder.ApplyConfiguration(new PersonConfig());
            ////دریافت کانفیگ از طریق فایل اسمبلی
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfig).Assembly);

            //این اینتیتی فاقد کلید اصلی است
            //modelBuilder.Entity<ReadOnlyFluent>().HasNoKey();

            //modelBuilder.Entity<IndexUsingFluent>().HasIndex(x => x.Name).IsUnique(); //HasFilter("Not Filtred");

            //ست کردن اسکیمای دیفالت پروژه
            //modelBuilder.HasDefaultSchema("ef1");

            //نام دلخواه برای جدول به همراه اسکیمای آن جدول
            //modelBuilder.Entity<TrainFluent>().ToTable("test_Train", "myShcema");

            //نام دلخواه برای یکی زا فیلد های جدول با فلوئنت
            //modelBuilder.Entity<TrainFluent>().Property(x => x.Name).HasColumnName("myFavorieName");

            //if (Database.IsSqlServer())
            //{
            //    //کانفیگ مورد نظر
            //}
            //if (Database.IsRelational())
            //{
            //    //کانفیگ مورد نظر
            //}

            modelBuilder.Entity<News>().Property<bool>("IsDeleted");

        }
    }
}
