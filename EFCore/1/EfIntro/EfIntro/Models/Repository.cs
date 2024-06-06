using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfIntro.Models
{
    public class Repository
    {
        public void AddPerson(string name, string lastName)
        {
            Person p = new Person()
            {
                FirstName = name,
                LastName = lastName
            };

            EfIntroDbContext dbContext = new EfIntroDbContext();

            dbContext.people.Add(p);
            dbContext.SaveChanges();
        }

        public void UpdatePerson(int id, string firstName, string lastName)
        {
            EfIntroDbContext dbContext = new EfIntroDbContext();

            Person person = dbContext.people.Find(id);

            if (person != null)
            {
                person.FirstName = firstName;
                person.LastName = lastName;
                dbContext.SaveChanges();
            }
        }

        public void PrintPepole()
        {
            EfIntroDbContext dbContext = new EfIntroDbContext();

            List<Person> people = dbContext.people.AsNoTracking().ToList();

            if (people.Any())
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Id} \t {person.FirstName} \t {person.LastName}");
                }
            }
        }

        public void DeletePersonById(int Id)
        {
            EfIntroDbContext dbContext = new EfIntroDbContext();

            Person person = dbContext.people.Find(Id);

            dbContext.people.Remove(person);

            dbContext.SaveChanges();
        }
    }
}
