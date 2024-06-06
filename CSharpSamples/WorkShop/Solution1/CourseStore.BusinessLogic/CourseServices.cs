using CourseStore.DAL.Context;
using CourseStore.DAL.Entites;

namespace CourseStore.BusinessLogic
{
    public class CourseServices
    {
        private readonly CourseStoreDbContext _courseStoreDbContext;
        public CourseServices(CourseStoreDbContext courseStoreDbContext)
        {
            _courseStoreDbContext = courseStoreDbContext;
        }


        public List<Course> GetAllCourses ()
        {
            return _courseStoreDbContext.Courses.ToList();
        }
    }
}