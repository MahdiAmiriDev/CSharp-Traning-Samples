using ControllersWithViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly PepoleDbContext pepoleDbContext;

        public HomeController(PepoleDbContext pepoleDbContext)
        {
            this.pepoleDbContext = pepoleDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Encodeing()
        {
            ViewBag.html =  "<h2> from html raw h2 tag </h2>";

            return View("Encoding", pepoleDbContext.Pepole.ToList());
        }
    }
}
