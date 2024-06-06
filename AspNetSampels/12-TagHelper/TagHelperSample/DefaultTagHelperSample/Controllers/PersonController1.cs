using DefaultTagHelperSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefaultTagHelperSample.Controllers
{
    public class PersonController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View(new Person());
        }

        [HttpPost]
        public IActionResult Save(Person person)
        {
            return RedirectToAction("save");
        }
    }
}
