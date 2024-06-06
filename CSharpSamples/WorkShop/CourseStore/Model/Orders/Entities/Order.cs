using CourseStore.Model.Courses.Entities;
using CourseStore.Model.FrameWork;

namespace CourseStore.Model.Orders.Entities
{
    public class Order : BaseEntity
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public int Price { get; set; }
    }
}
