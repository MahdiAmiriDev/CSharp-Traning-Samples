namespace AutoMapperSample.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
