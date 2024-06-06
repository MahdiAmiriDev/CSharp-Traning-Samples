using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.TabelPerType
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Teacher:Person
    {
        public int TeacherNumber { get; set; }

    }

    public class Student:Person
    {
        public int StudentNumber { get; set; }
    }

    public class TphDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog= TphDb;Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //برای هر کدام جدول جدید می سازد چون خودمان گفتیم بسازد با این که هیج کدام ای دی ست نکردیم
            modelBuilder.Entity<Teacher>().ToTable("teacher");
            modelBuilder.Entity<Student>().ToTable("teacher");
        }  
    }
}
