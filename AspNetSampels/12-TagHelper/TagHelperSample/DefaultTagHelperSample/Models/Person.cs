using System.ComponentModel.DataAnnotations;

namespace DefaultTagHelperSample.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; } = "majid";
        [Required]
        public string LastName { get; set; } = "razavi";
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
