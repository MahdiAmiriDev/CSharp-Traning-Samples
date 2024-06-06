using CourseStore.Model.Courses.Entities;
using CourseStore.Model.FrameWork;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.Model.CourseTag.Entites
{
    public class CourseTags:BaseEntity
    {
        public Course Course { get; set; }
        public Tag Tags { get; set; }
        public int CourseId { get; set; }
        public int TagId { get; set; }
    }
}
