using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.Dal
{
    public class CourseStoreRepository
    {
        private readonly CourseStoreDbContext _courseStoreDbContext;

        public CourseStoreRepository(CourseStoreDbContext courseStoreDbContext) 
        {
            _courseStoreDbContext = courseStoreDbContext;
        }

        public void PrintCourseAndTeachers()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            var resul = _courseStoreDbContext.Courses.Include(x => x.CourseTeachers).
                ThenInclude(c => c.Teacher).ToList();

            foreach (var course in resul)
            {
                Console.WriteLine($"Course:{course.Name}");
                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teacher:{teacher.Teacher.FirstName}");
                }
            }
            Console.WriteLine("".PadLeft(100, '*'));
        }

        public void PrintCourseAndTeachersAndTags()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            var resul = _courseStoreDbContext.Courses.Include(x => x.CourseTeachers
            .OrderByDescending(c => c.SortOrder)).
                ThenInclude(c => c.Teacher)
                .Include(c => c.Tags.Take(2))
                .ToList();

            foreach (var course in resul)
            {
                Console.WriteLine($"Course:{course.Name}");
                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teacher:{teacher.Teacher.FirstName}");
                }

                foreach (var item in course.Tags)
                {
                    Console.WriteLine($"Tag:{item.Name}");
                }
            }
            Console.WriteLine("".PadLeft(100, '*'));
        }

        public void PrintCourseAndTeachersExplicit()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            var resul = _courseStoreDbContext.Courses.ToList();

            foreach (var course in resul)
            {
                if (DateTime.Now.Hour == 20)
                {
                    _courseStoreDbContext.Entry(course).Collection(c => c.CourseTeachers).Load();   

                    foreach (var courseTeacher in course.CourseTeachers)
                    {
                        _courseStoreDbContext.Entry(courseTeacher).Reference(x => x.Teacher).Load();
                        Console.WriteLine($"Teacher:{courseTeacher.Teacher.FirstName}");
                    }
                }
            }
            Console.WriteLine("".PadLeft(100, '*'));
        }

        public void CourseShortInfoDtoSelectLoading()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            var resul = _courseStoreDbContext.Courses.Select(c => new CourseShortInfoDto
            {
                Id = c.CourseId,
                Name = c.Name
            });

            foreach (var course in resul)
            { 
                Console.WriteLine($"Course:{course.Name}");
            }
            Console.WriteLine("".PadLeft(100, '*'));
        }

        public void CientVsServer()
        {
            Console.WriteLine("".PadLeft(100, '*'));

            var reslut = _courseStoreDbContext.Courses.Include(x => x.Tags)
                .Select(c => new
                {
                    c.CourseId,
                    c.Name,
                    c.StartDateTime,
                    tag = string.Join(',', c.Tags)
                });

            foreach (var item in reslut)
            {
                Console.WriteLine($"{item.Name}:{item.tag}");
            }
        }

        public void PrintOrderedTag()
        {
            var tagOrderBy = _courseStoreDbContext.Tags.OrderBy(t => t.Name).ToList();

            foreach (var item in tagOrderBy) 
            {
                Console.WriteLine($"{item.TagId}:{item.Name}");
            }
            Console.WriteLine("".PadLeft(100, '*'));

            var tagOrderByDesc = _courseStoreDbContext.Tags.OrderByDescending(c => c.Name).ToList();

            foreach (var item in tagOrderByDesc)
            {
                Console.WriteLine($"{item.TagId}:{item.Name}");
            }
        }

        public void PrintTagLike()
        {
            var tagLike = _courseStoreDbContext.Tags.Where(c => EF.Functions.Like(c.Name, "%asp%")).ToList();

            //var tagLike = _courseStoreDbContext.Tags.Where(c => c.Name.Contains("asp")).ToList();

            foreach (var item in tagLike)
            {
                Console.WriteLine($"{item.TagId}:{item.Name}");
            }
        }

        public void Paging()
        {
            var tagLike = _courseStoreDbContext.Tags.Skip(2).Take(2).ToList();

            //var tagLike = _courseStoreDbContext.Tags.Where(c => c.Name.Contains("asp")).ToList();

            foreach (var item in tagLike)
            {
                Console.WriteLine($"{item.TagId}:{item.Name}");
            }
        }

    }
}
