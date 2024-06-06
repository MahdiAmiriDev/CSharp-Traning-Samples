using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguration.OwnedTypeSample
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }

        public Car Car { get; set; }

        public List<Money> Money { get; set; }

    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class Car
    {
        public string  CarName { get; set; }
    }

    public class Money
    {
        public int MoneyId { get; set; }
        public int Value { get; set; }
    }

    public class OwnedTypeContext :DbContext
    {
        public DbSet<Person> MyProperty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog= OwnedTypeDb;Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //با این روش مشخص می کنیم که رابطه این دو موجدیت برای گروه بندی است 
            // نه به صورت ریلیشن و کلید و ... در غیر این صورت اگر مشخص نشود
            // هنگام مارگریشن زدن دچار خطا می شویم
            modelBuilder.Entity<Person>(p =>
            {
                p.OwnsOne(x => x.Address);

                //در این حالت جدول را در دیتا بیسی می سازد همچنین به هنگام کوئری زدن
                //به برسن دیگر نیازی به اینکلود کردن کار نیست چون خودش می آورد کامل آن را
                p.OwnsOne(x => x.Car).ToTable("cars");

                //در حالت یک به چند نیز تمامی مقدار ها را لود می کند بدون اینکه کاربر اینکلود بزند
                p.OwnsMany(x => x.Money).ToTable("Money");
            });
        }
    }
}
