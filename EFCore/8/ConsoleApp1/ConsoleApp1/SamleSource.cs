using ConsoleApp1.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SamleSource
    {
        private readonly MyDbContext _myDbContext;

        public SamleSource(MyDbContext myDbContext)
        {
           _myDbContext = myDbContext;
        }

        public void SetEntityState(int id , string firstName , string lastName)
        {

            // به صورت دستی تشخیص تغییرات را غیر فعال کنیم
            // _myDbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            Person person = new Person 
            {
                Id = id ,
                FirstName = firstName ,
                LastName = lastName
            };

            Console.WriteLine($"person state is {_myDbContext.Entry(person).State}");

            _myDbContext.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _myDbContext.Entry(person).Property(x => x.LastName).IsModified = false;
        }

        public void ContextIdSample()
        {
            MyDbContext ctx1 = new();
            MyDbContext ctx2 = new();

            Console.WriteLine($"my first db context id is {ctx1.ContextId}");
            Console.WriteLine($"my second db context id is {ctx2.ContextId}");

            
        }

        public void UpadteTeacherValues(int id , string firstName , string lastName)
        {
            var teacher = _myDbContext.Teachers.SingleOrDefault(x => x.Id == id);

            if(teacher != null)
            {
                teacher.FistName = firstName;
                teacher.LastName = lastName;
                _myDbContext.SaveChanges();
            }
        }
         
        public void ShowChangeTrackerDebugView()
        {
            Console.WriteLine("-----------------short-------------");
            Console.WriteLine(_myDbContext.ChangeTracker.DebugView.ShortView);
            Console.WriteLine("-----------------long-------------");
            Console.WriteLine(_myDbContext.ChangeTracker.DebugView.LongView);
        }

        public void FromSqlRawSample()
        {
            var pepole = _myDbContext.People.FromSqlRaw("select * from People").OrderBy(x => x.LastName).ToList();

            int id = 1;
            var pepole2 = _myDbContext.People.FromSqlInterpolated($"select * from People where id = {id}").OrderBy(x => x.LastName)
                    .SingleOrDefault();

            foreach(var person in pepole)
            {
                Console.WriteLine($"{person.FirstName} \t {person.LastName}");
            }

            pepole[0].FirstName = "myTest";

            _myDbContext.SaveChanges();
        }

        public void WriteSqlRawToDataBase()
        {
            _myDbContext.Database.ExecuteSqlRaw("Insert into People(FirstName,LastName) Values('test','testfamily')");
        }

        //تغییر رشته اتصال بانک اطلاعاتی پس از این که برنامه ران شده است
        public void ChangeConnectionString()
        {
             Person person = new Person
             {
                 FirstName ="test2",
                 LastName ="test2",
             };

            var myNewConnectionString = new MyDbContext();

            myNewConnectionString.Database.SetConnectionString("server=.;initial catalog = test;integrated security=true");

            myNewConnectionString.People.Add(person);

            myNewConnectionString.SaveChanges();
        }

        public void addStudenWithOutAudiDate()
        {
            Student student = new Student
            {
                FirstName = "ali",
                LastName = "karami"
            };

            _myDbContext.Students.Add(student);
            _myDbContext.SaveChanges();
        }
    }
}
