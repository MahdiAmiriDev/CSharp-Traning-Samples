using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyMbDbContext _myMbDbContext;

        public ProductController(MyMbDbContext myMbDbContext)
        {
            _myMbDbContext = myMbDbContext;
        }
        public IActionResult Index(int? id)
        {
            if (!id.HasValue || id.Value == 0)
                return View("Error");


            var p = _myMbDbContext.Product.Include(c => c.Category).Where(x => x.Id == id).FirstOrDefault();

            return View(p);
        }

        public IActionResult Save(int id = 1)
        {
            var p = _myMbDbContext.Product.Include(c => c.Category).Where(x => x.Id == id).FirstOrDefault();

            return View(p);
        }

        [BindProperty]
        public Product PFromBinder { get; set; }

        [HttpPost]
        public IActionResult Save(Product input)
        { 
          return View("Result",input);
        }

        public IActionResult SaveCategory(Category category)
        {
            return Json(category);
        }

        //[HttpPost]
        //public IActionResult Save([Bind("Name")] Product input)
        //{
        //    return View("Result", input);
        //}

        //[HttpPost]
        //public IActionResult Save([Bind(Prefix="aaa.cate")] Product input)
        //{
        //    return View("Result", input);
        //}
    }
}
