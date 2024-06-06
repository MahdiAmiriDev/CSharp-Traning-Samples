using ControllersWithViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViews.Controllers
{
    public class PepoleController : Controller
    {
        private readonly PepoleDbContext _pepoleDbContext;

        public PepoleController(PepoleDbContext pepoleDbContext)
        {
            _pepoleDbContext = pepoleDbContext;
        }

        //[HttpGet]
        //public IActionResult GetAllPepole()
        //{
        //    return _pepoleDbContext.Pepole.ToList(); 
        //}

        
        public IActionResult GetAllPepole()
        {
            return View(_pepoleDbContext.Pepole.ToList());
        }

        public IActionResult TestViewBag()
        {
            ViewBag.Title = "hello kitty";

            return View();
        }
    }
}
