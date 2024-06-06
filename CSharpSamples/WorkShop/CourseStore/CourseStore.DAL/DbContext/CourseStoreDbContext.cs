using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Orders.Entities;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL
{
    public class CourseStoreDbContext :DbContext
    {
        private readonly string _connetionString;
        public CourseStoreDbContext(string connectionString)
        {
            _connetionString = connectionString;
        }
        public CourseStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }



        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //روشی برای کانفیگ کردن به صورت گلوبال برای تمامی استرینگ ها
            //configurationBuilder.Properties<string>().HaveMaxLength(500);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //شناسایی کانفیگ به ای اف از طریق معرفی تک به تک کلاس های کانفیگ
            //modelBuilder.ApplyConfiguration(new CourseConfig());

            //معرفی کانفیگ انتیتی های به صورت معفرفی اسمبلی کانفیگ
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //افزودن فیلد های جنرال به تمامی انتیتی 
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("CreationDate").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
            }
        }


    }
}
