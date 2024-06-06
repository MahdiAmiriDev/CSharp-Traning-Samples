using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public static List<Student> GetStudents() =>
            new List<Student>
            {
                new Student { Id = 1 , FirstName = "ali" , LastName = "karami" , Grade = 20},
                new Student { Id = 2 , FirstName = "mehrad" , LastName = "karami" , Grade = 20},
                new Student { Id = 3 , FirstName = "mmd" , LastName = "alipor" , Grade = 19},
                new Student { Id = 4 , FirstName = "souroush" , LastName = "alipor" , Grade = 19},
                new Student { Id = 5 , FirstName = "karim" , LastName = "jamali" , Grade = 15},
                new Student { Id = 6 , FirstName = "bahram" , LastName = "jamali" , Grade = 15},
                new Student { Id = 7 , FirstName = "reza" , LastName = "jamali" , Grade = 15},
                new Student { Id = 8 , FirstName = "saba" , LastName = "saberi" , Grade = 12},
                new Student { Id = 9 , FirstName = "parinaz" , LastName = "hosseini" , Grade = 4},
                new Student { Id = 10 , FirstName = "mahsa" , LastName = "jafari" , Grade = 11},
                new Student { Id = 11 , FirstName = "sara" , LastName = "amiri" , Grade = 2},
                new Student { Id = 12 , FirstName = "saeed" , LastName = "solymani" , Grade = 18},
                new Student { Id = 13 , FirstName = "jj" , LastName = "solymani" , Grade = 18},
                new Student { Id = 14 , FirstName = "sijaz" , LastName = "solymani" , Grade = 18},
            };

        public static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"student name :{ student.FirstName} lastName :{student.LastName}" +
                    $"Grade:{student.Grade}");
            }

            Console.WriteLine("-".PadLeft(50));
        }
    }

    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }        

        public static List<StudentCourse> GetStudentCourses() =>
            new List<StudentCourse>
            {
                new StudentCourse{Id = 1, StudentId = 1 , Name="asp",Score = 20},
                new StudentCourse{Id = 2, StudentId = 1 , Name="sql",Score = 18},
                new StudentCourse{Id = 3, StudentId = 2 , Name="asp",Score = 15},
                new StudentCourse{Id = 4, StudentId = 2 , Name="ef core",Score = 20},
                new StudentCourse{Id = 5, StudentId = 3 , Name="asp",Score = 19},
                new StudentCourse{Id = 6, StudentId = 4 , Name="ef",Score = 12},
            };

    }
}
