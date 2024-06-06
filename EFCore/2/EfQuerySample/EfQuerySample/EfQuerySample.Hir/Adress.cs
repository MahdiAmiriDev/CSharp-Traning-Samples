namespace EfQuerySample.Hir
{
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; }
        public Person person { get; set; }
    }
}
