using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class LinqOperators
    {

        public void PrintWithOutLinq()
        {
            List<string> a = new();
            List<string> list = new()
            {
                "Mammad",
                "Ali",
                "Omid",
                "Ahmad",
                "Akbar"
            };

            list.ForEach(x =>
            {
                if (x.StartsWith("A"))
                {
                    a.Add(x);
                }
            });

            a.Sort();

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintWithLinq()
        {
            List<string> list = new()
            {
                "Mammad",
                "Ali",
                "Omid",
                "Ahmad",
                "Akbar"
            };

            var result = from x in list
                         where x.StartsWith("A")
                         orderby x
                         select x;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintWithMethod()
        {
            List<string> list = new()
            {
                "Mammad",
                "Ali",
                "Omid",
                "Ahmad",
                "Akbar"
            };

            var result = list.Where(x => x.StartsWith("A")).OrderBy(x => x).Select(x => x);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// کوئری در زمان فراخوانی اجرا می شود نه در زمان نوشتن کد
        /// حالت اجرا درجا با استفاده از 
        /// tolist toarray , .....
        /// </summary>
        public void printNumbersDiferred()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            //فقط کوئری است بدون اجرا بعدا اجرا میشود
            //Diferred اجرا می شود
            var reslut = from x in list where x < 10 select x;

            //در این جا یک بار اجرا شده و تمام
            var immediate = (from x in list where x < 10 select x).ToList();

            foreach (var item in reslut)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("#########################################################");

            list.AddRange(new List<int> { 12, 13, 14, 15, 1 });

            foreach (var item in reslut)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// عملیات فیلتر با استفاده از لینک
        /// </summary>
        public void FilterStudentsByLinq()
        {
            var students = Student.GetStudents();

            var reslut = (from s in students where s.Grade > 15 select s).ToList();

            Student.PrintStudents(reslut);
        }

        /// <summary>
        /// عملیات فیلتر با استفاده از متد
        /// </summary>
        public void FilterStudentsByMethod()
        {
            var students = Student.GetStudents();

            var result = students.Where((s, index) => s.Grade > 15 && s.Grade > index).ToList();

            Student.PrintStudents(result);
        }

        /// <summary>
        /// عملیات فیلتر با استفاده از نوع
        /// </summary>
        public void FilterByType()
        {
            List<object> list = new() { 1, 2, "ali", 23, "salman", "farah" };

            var result = list.OfType<string>().ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void StartLinqFilter()
        {
            FilterStudentsByLinq();

            Task.Delay(1000).Wait();

            FilterStudentsByMethod();

            Task.Delay(1000).Wait();

            FilterByType();

        }
        //------------------------------OrderBy and ThenBy

        //ترتیب صعودی
        public void StudentsOrderByGrade()
        {
            var students = Student.GetStudents();

            var orderedStudents = students.OrderBy(x => x.Grade).ToList();

            Student.PrintStudents(orderedStudents);
        }

        //ترتیب نزولی
        public void OrderByDescenind()
        {
            var students = Student.GetStudents();

            var result = students.OrderByDescending(x => x.Grade).ToList();

            Student.PrintStudents(result);
        }

        // ترتیب بر اساس چمد پارامتر
        public void MultipleOrderWithThenBy()
        {
            var students = Student.GetStudents();

            var result = students.OrderBy(x => x.Grade).ThenBy(x => x.FirstName).ToList();

            var result2 = students.OrderBy(x => x.Grade).ThenByDescending(x => x.FirstName).ToList();

            Student.PrintStudents(result);

            Task.Delay(1000).Wait();

            Student.PrintStudents(result2);
        }

        public void StartOrder()
        {
            StudentsOrderByGrade();
            Task.Delay(1000).Wait();
            OrderByDescenind();
            Task.Delay(1000).Wait();
            MultipleOrderWithThenBy();
        }

        //-----------------------------------------Group by

        /// <summary>
        /// گروه بندی بر اساس نمره کسب شده توسط دانش آموزان
        /// به این صورت کلید گروه ها نمره است 
        /// </summary>
        public void GroupStudent()
        {
            var students = Student.GetStudents();

            var groupByGrade = students.GroupBy(x => x.Grade);

            foreach (var item in groupByGrade)
            {
                Console.WriteLine(item.Key);

                foreach (var student in item)
                {
                    Console.WriteLine($"name : {student.FirstName} , grade:{student.Grade}");
                }

                Console.WriteLine("".PadLeft(50, '*'));
            }
        }

        //---------------------- InnerJoin

        /// <summary>
        /// جوین زدن 2 تا موجودیت بر اساس شناسه مشترک بین آن ها
        /// </summary>
        public void InnerJoin()
        {
            var students = Student.GetStudents();

            var courses = StudentCourse.GetStudentCourses();

            var result = students.Join(courses, s => s.Id, c => c.StudentId, (s, c) => new
            {
                StudentId = s.Id,
                StudentName = s.FirstName,
                CourseName = c.Name,
                CourseGrade = c.Score
            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"studentName:{item.StudentName}\n studentId : {item.StudentId} \n score:{item.CourseGrade}");
                Console.WriteLine("".PadLeft(50,'*'));
            }

        }

        //left join => group join
        
        public void GroupJoin()
        {
            var students = Student.GetStudents();

            var courses = StudentCourse.GetStudentCourses();

            var result = students.GroupJoin(courses, s=> s.Id,c => c.StudentId , (s,c) => new
            {
                s.Id,
                s.FirstName,
                s.LastName,
                StudentCourses = c

            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"id:{item.Id}\n fName : {item.FirstName} \n courses:{item.StudentCourses.Count()}");
                Console.WriteLine("".PadLeft(50, '*'));
            }
        }

        public void LeftJoin()
        {
            var students = Student.GetStudents();

            var courses = StudentCourse.GetStudentCourses();

            var result = students.GroupJoin(courses, s => s.Id, c => c.StudentId, (s, c) => new
            {
                s.Id,
                s.FirstName,
                s.LastName,
                StudentCourses = c

            }).SelectMany(s => s.StudentCourses.DefaultIfEmpty(), (s, c) => new
             {
                s.Id,
                s.FirstName,
                s.LastName,
                StudentCourses = c?.Name ?? "---"
             });

            foreach (var item in result)
            {
                Console.WriteLine($"id:{item.Id}\n fName : {item.FirstName} \n courses:{item.StudentCourses}");
                Console.WriteLine("".PadLeft(50, '*'));
            }
        }

        //----------------------- Set Operators

        public void Distinct()
        {
            List<int> ints = new() { 1, 2, 3, 5, 6, 3, 2, 6, 7, 8, 9 };

            var distinct = ints.Distinct();

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }

        public void Union()
        {
            List<int> ints = new() { 1, 2, 3, 5, 6, 3, 2, 6, 7, 8, 9 };
            List<int> int2 = new() { 1, 2, 3, 5, 6, 3, 2, 6, 7, 8, 9,10,11,12,13,14 };

            var union = ints.Union(int2);

            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
        }

        public void UnionBy()
        {
            List<StudentCourse> sc1 = new ()
            {
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 4 },
            };
            List<StudentCourse> sc2 = new()
            {
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 5 },
                new StudentCourse { Id = 6 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 2 },
            };

            var res = sc1.UnionBy(sc2, s => s.Id);

            foreach (var item in res)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void ExceptBy()
        {
            List<StudentCourse> sc1 = new()
            {
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 4 },
            };
            List<StudentCourse> sc2 = new()
            {
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 5 },
                new StudentCourse { Id = 6 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 2 },
            };

            var res = sc1.ExceptBy(new int[] { 1, 2 }, s => s.Id);

            foreach (var item in res)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void DistinctBy()
        {
            List<StudentCourse> sc1 = new()
            {
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 4 },
            };
            List<StudentCourse> sc2 = new()
            {
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 5 },
                new StudentCourse { Id = 6 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 2 },
            };

            var res = sc1.DistinctBy(s => s.Id);

            foreach (var item in res)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void Intersect()
        {
            List<StudentCourse> sc1 = new()
            {
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 4 },
            };
            List<StudentCourse> sc2 = new()
            {
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 5 },
                new StudentCourse { Id = 6 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 2 },
            };

            var res = sc1.IntersectBy(new int[] {1,2}, s => s.Id);

            foreach (var item in res)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void Except()
        {
            List<StudentCourse> sc1 = new()
            {
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 4 },
            };
            List<StudentCourse> sc2 = new()
            {
                new StudentCourse { Id = 2 },
                new StudentCourse { Id = 4 },
                new StudentCourse { Id = 5 },
                new StudentCourse { Id = 6 },
                new StudentCourse { Id = 1 },
                new StudentCourse { Id = 3 },
                new StudentCourse { Id = 2 },
            };

            var res = sc1.Except(sc2);

            foreach (var item in res)
            {
                Console.WriteLine(item.Id);
            }
        }
        //------------------- ZIP
        // دو مچموعه داریم یکی 2 عضو یکی 3 عضو دارد 
        // اولی رو با اولی و دومی را با دومی و را در کنار هم میزاره مثل دندونه های زیپ

        public void Zip()
        {
            List<int> ints = new() { 1, 2, 3, 5, 6, 3, 2, 6, 7, 8, 9 };
            List<int> int2 = new() { 1, 2, 3, 5, 6, 3, 2, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            var res = ints.Zip(int2);

        }

        //-------partiion with take and skip

        public void TakeAndSkip(int pageIndex = 0 , int pageCount = 3)
        {
            List<int> ints = new() { 1, 2, 3, 4,5,6,7,8,9,10 };

            var reslut = ints.Skip(pageCount * pageIndex).Take(pageCount);

            foreach (var item in reslut)
            {
                Console.WriteLine(item);
            }
            
        }

        // Chunk
        // خورد کردن مجموعه و مثلا 10 تا 10 تا خورد کردیم دادیم به db

        public void Chunk(int size = 3)
        {
            List<int> ints = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var res = ints.Chunk(size);

            foreach (var item in res)
            {
                foreach (var i in item)
                {
                    Console.WriteLine(i);
                }
            }
            
        }

        public void Aggregation()
        {
            var stu = Student.GetStudents();

            var totalCount = stu.Count();
            
            var minValue = stu.Min(x => x.Grade);

            var maxValue = stu.Max(x => x.Grade);

            var avg = stu.Average(x => x.Grade);

            var sum = stu.Sum(x => x.Id);

            var sum2 = stu.Sum(x => x.Grade);
        }

        public void Generators()
        {
            var t5 = Enumerable.Range(0, 100).ToList();
            var t4 = Enumerable.Empty<int>().ToList();
            var t3 = Enumerable.Repeat<int>(1, 300).ToList();
            var t2 = Enumerable.Repeat(1, 300).ToList();
        }
    }
}
