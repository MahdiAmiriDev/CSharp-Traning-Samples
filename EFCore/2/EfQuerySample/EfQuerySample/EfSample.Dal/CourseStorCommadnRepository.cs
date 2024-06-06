using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.Dal
{
    public class CourseStorCommadnRepository
    {
        private readonly CourseStoreDbContext _context;

        public CourseStorCommadnRepository(CourseStoreDbContext context)
        {
            _context = context;
        }

        public void AddTag(string name)
        {
            Tag tag = new Tag
            {
                Name = name
            };

            Console.WriteLine($"tag state is {_context.Entry(tag).State}");
            _context.Tags.Add(tag);
            Console.WriteLine($"tag state is {_context.Entry(tag).State}");
            _context.SaveChanges();
            Console.WriteLine($"tag state is {_context.Entry(tag).State}");
        }

        public void AddCourseWithComments(string courseName, int coursePrice)
        {
            Course course = new Course
            {
                Name = courseName,
                Price = coursePrice,
                Description = $"{courseName} is good for proffesional programers",
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        CommentBy = "First Student",
                        CommentText = $"{courseName} is very useful",
                        IsApproved = true,
                        StartCount = 4
                    },
                    new Comment
                    {
                        CommentBy = "Secong Student",
                        CommentText = $"{courseName} was good for me",
                        IsApproved = true,
                        StartCount = 4
                    }
                }
            };

            Console.WriteLine($"course state is {_context.Entry(course).State}");
            Console.WriteLine($"comment state is {_context.Entry(course.Comments.First()).State}");
            _context.Courses.Add(course);
            Console.WriteLine($"course state is {_context.Entry(course).State}");
            Console.WriteLine($"comment state is {_context.Entry(course.Comments.First()).State}");
            _context.SaveChanges();
            Console.WriteLine($"course state is {_context.Entry(course).State}");
            Console.WriteLine($"comment state is {_context.Entry(course.Comments.First()).State}");
        }

        public void UpdateTagById(int tagId , String newName)
        {
            var tag = _context.Tags.Find(tagId);

            tag.Name = newName;

            _context.SaveChanges();
        }

        public CourseInfoDto GetCourseInfoById(int courseId)
        {
            var courseShortInfo = _context.Courses.Where(x => x.CourseId == courseId)
                .Select(s => new CourseInfoDto
                {
                    CourseId = s.CourseId,
                    Name = s.Name,
                    Description = s.Description
                }).FirstOrDefault();

            return courseShortInfo;
        }

        public void SaveCourse(CourseInfoDto courseDto)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == courseDto.CourseId);

            course.Name = courseDto.Name;
            course.Description = courseDto.Description;

            _context.SaveChanges();
        }

        public string GetTagNameById(int id)
        {

            var result = _context.Tags.FirstOrDefault(x => x.TagId == id).Name;

            return result;
        }

        public void UpdateTagDisconnected(int tagId , string tagName)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
            optionBuilder.UseSqlServer("Server=.;Database=CourseDb;Integrated Security = true");
            using CourseStoreDbContext disconnectedContext = new CourseStoreDbContext(optionBuilder.Options);


            Tag tag = new Tag
            {
                TagId = tagId,
                Name = tagName,
            };

            disconnectedContext.Tags.Update(tag);
            disconnectedContext.SaveChanges();
        }

        public void SoftDeleteCourse(int courseId)
        {
            var course = _context.Courses.SingleOrDefault(x => x.CourseId == courseId);

            course.IsDeleted = true;

            _context.SaveChanges();
        }

        public void ShowAllCourse()
        {
            var courses = _context.Courses.IgnoreQueryFilters().ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId} : {course.Name}");
            }
        }


        public void DeleteTagById(int tagId)
        {
            var tag = _context.Tags.SingleOrDefault(t => t.TagId == tagId);

            _context.Tags.Remove(tag);

            _context.SaveChanges();
        }

        public void DeleteTagByIdWithBetterPerformance(int tagId)
        {
            var tag = new Tag { TagId = tagId };

            _context.Tags.Remove(tag);

            _context.SaveChanges();
        }
    }
}
