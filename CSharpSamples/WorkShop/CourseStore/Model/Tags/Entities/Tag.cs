using CourseStore.Model.Courses.Entities;
using CourseStore.Model.CourseTag.Entites;
using CourseStore.Model.FrameWork;

namespace CourseStore.Model.Tags.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public List<CourseTags> CourseTags { get; set; }
    }
}
