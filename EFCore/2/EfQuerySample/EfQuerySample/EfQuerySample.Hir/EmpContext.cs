using Microsoft.EntityFrameworkCore;

namespace EfQuerySample.Hir
{
    public class EmpContext:DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Type01> Type01s { get; set; }
        public DbSet<Type02> Type02s { get; set; }
        public DbSet<Type03> Type03s { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EmpDb;Integrated Security = true");
        }
    }
}
