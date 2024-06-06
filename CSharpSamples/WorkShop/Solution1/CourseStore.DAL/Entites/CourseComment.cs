namespace CourseStore.DAL.Entites
{
    public class CourseComment:BaseEntity
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public string CommentBy { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsValid { get; set; }
        public string Comment { get; set; }
    }
}
