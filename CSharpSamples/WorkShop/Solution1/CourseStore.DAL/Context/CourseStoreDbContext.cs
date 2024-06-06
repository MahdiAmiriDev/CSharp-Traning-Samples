using CourseStore.DAL.Entites;
using CourseStore.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.DAL.Context
{
    public class CourseStoreDbContext:DbContext
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
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }


    }    
}
