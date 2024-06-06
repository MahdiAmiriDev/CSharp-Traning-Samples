using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfQuerySample.Hir
{
    public class Person
    {
        //public Person(string firstName)
        //{
        //    firstName = firstName.Trim()+"jafari";
        //}
        //private readonly ILazyLoader _lazyLoader;
        //public Person(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}

        public int Id { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }

        public List<Adress> Adresses {get; set;}
        //public List<Adress> Adresses { get => _lazyLoader.Load(this,ref _adresses); set => _adresses = value; }

    }
}
