namespace SimpleEfConfigurationSamples.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
