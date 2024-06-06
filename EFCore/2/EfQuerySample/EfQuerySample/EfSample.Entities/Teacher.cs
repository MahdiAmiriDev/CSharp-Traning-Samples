namespace EfSample.Entities
{

    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public Teacher Teacher { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }
    }
}