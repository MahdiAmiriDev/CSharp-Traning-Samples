using EFQuerySample.LazyLoading;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<LazyDbContext>();


optionBuilder.UseSqlServer("Server=.;Database=LazyLoadingDb;Integrated Security = true;MultiplActiveResultSets=true");
optionBuilder.UseLazyLoadingProxies();
using  LazyDbContext ctx = new LazyDbContext(optionBuilder.Options);

var pepole = ctx.People;

foreach (var person in pepole)
{
    Console.WriteLine($"{person.Id}");
    foreach (var address in person.Addresses)
    {
        Console.WriteLine($"{address.Id},{address.City}");
    }
}