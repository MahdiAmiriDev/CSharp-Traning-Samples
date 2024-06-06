using EfSample.Dal;
using EfSmple.UI;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();


optionBuilder.UseSqlServer("Server=.;Database=CourseDb;Integrated Security = true");


using CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);



//CourseStoreRepository repository = new CourseStoreRepository(ctx);

//EntityStatePrinter entityStatePrinter = new EntityStatePrinter(ctx);

//CourseStorCommadnRepository courseStorCommadnRepository = new CourseStorCommadnRepository(ctx);

//repository.PrintCourseAndTeachers();


//repository.PrintCourseAndTeachersAndTags();

//repository.CientVsServer();

//repository.PrintOrderedTag();

//repository.PrintTagLike();

//repository.Paging();

//entityStatePrinter.PrintDetachState();

//entityStatePrinter.PrintAddedState();

//entityStatePrinter.PrintAddedState();

//entityStatePrinter.PrintUnchangedState()


//courseStorCommadnRepository.AddTag($"AddedTag{DateTime.Now.Ticks}");

//courseStorCommadnRepository.AddCourseWithComments("NikAmooz EF Core", 1000);

//courseStorCommadnRepository.UpdateTagById(1, "Asp .Net Pro 6");

//var courseDto = courseStorCommadnRepository.GetCourseInfoById(1);
////Show In Web Page
//courseDto.Description = "updated description for Pro .Net EcoSystem";

//courseStorCommadnRepository.SaveCourse(courseDto);

//int tagId = 1;

//var tagName = courseStorCommadnRepository.GetTagNameById(tagId);

//courseStorCommadnRepository.UpdateTagDisconnected(tagId, tagName + "Updated");

//repository.CourseShortInfoDtoSelectLoading();

//courseStorCommadnRepository.GetTagNameById(1);

//courseStorCommadnRepository.DeleteCourse(1);
//courseStorCommadnRepository.ShowAllCourse();

//courseStorCommadnRepository.DeleteTagById(5);
//courseStorCommadnRepository.DeleteTagByIdWithBetterPerformance(6);

//--------------------------------session 4 ---------------------------------

//var course = ctx.Courses.Where(x => x.CourseId == 2).SingleOrDefault();
//var comments = ctx.Comments.Where(x => x.CourseId == course.CourseId).ToList();

var courses = ctx.Courses.AsNoTracking().Include(x => x.CourseTeachers)
    .ThenInclude(c => c.Teacher).ToList();

//var courses2 = ctx.Courses.AsNoTrackingWithIdentityResolution().Include(x => x.CourseTeachers)
//    .ThenInclude(c => c.Teacher).ToList();


var c1t1 = courses.Where(c => c.CourseId == 1).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;









Console.ReadKey();