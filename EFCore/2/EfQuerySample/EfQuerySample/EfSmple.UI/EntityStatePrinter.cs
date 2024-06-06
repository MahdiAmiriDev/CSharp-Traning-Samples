using EfSample.Dal;
using EfSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSmple.UI
{
    public class EntityStatePrinter
    {
        private readonly CourseStoreDbContext _context;
        public EntityStatePrinter(CourseStoreDbContext context)
        {
            _context = context;
        }

        public void PrintDetachState()
        {
            Tag tag = new Tag();

            var entityState = _context.Entry(tag).State;

            Console.WriteLine(entityState);
        }

        public void PrintAddedState()
        {
            Tag tag = new Tag();

            _context.Add(tag);

            var tagState = _context.Entry(tag).State;

            Console.WriteLine($"tag added state is :{tagState}");
        }

        public void PrintDeleteState()
        {
            Tag tag = new Tag()
            {
                TagId = 1
            };

            _context.Remove(tag);

            var tagState = _context.Entry(tag).State;

            Console.WriteLine($"tag Deleted state is :{tagState}");
        }

        public void PrintUpdateState()
        {
            Tag tag = new Tag()
            {
                TagId = 1
            };

            _context.Update(tag);

            var tagState = _context.Entry(tag).State;

            Console.WriteLine($"tag Deleted state is :{tagState}");
        }

        public void PrintUnchangedState()
        {
           Tag tag =  _context.Tags.FirstOrDefault(c => c.TagId == 2);

            var tagState = _context.Entry(tag).State;

            Console.WriteLine($"tag Deleted state is :{tagState}");
        }
    }
}
