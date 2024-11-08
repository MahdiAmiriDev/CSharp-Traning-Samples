using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.TphSamle
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
        //دی بی ست ها باعث ایجاد جدول جدید نمی شوند 
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog= TphDb;Integrated Security = True;rustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(p =>
            {
                //کانفیگ کردن دیسکریمنتور به صورت دلخواه خودمان
                p.HasDiscriminator<int>("Disc").HasValue<Person>(1).HasValue<Teacher>(2)
                .HasValue<Student>(3);
            });
        }
    }
}
