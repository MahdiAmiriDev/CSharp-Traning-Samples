using Microsoft.EntityFrameworkCore;
using EfSample.Entities;
namespace EfSample.Dal
{
    public class CourseStoreDbContext : DbContext
    {

        #region Dbsets
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; } 
        #endregion

        #region Constractor
        public CourseStoreDbContext(DbContextOptions<CourseStoreDbContext> options) : base(options)
        {

        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}