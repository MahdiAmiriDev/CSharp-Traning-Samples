using EfSample.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfSmple.UI
{
    public class CourseStoreContextFactory : IDesignTimeDbContextFactory<CourseStoreDbContext>
    {
        public CourseStoreDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();


            optionBuilder.UseSqlServer("Server=.;Database=CourseDb;Integrated Security = true");


            CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options); 

            return ctx;
        }
    }
}
