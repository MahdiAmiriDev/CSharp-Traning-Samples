using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IntInput(int id)
        {
            return View(id);
        }

        public IActionResult boolInput(bool value)
        {
            return View(value);
        }

        [HttpPost]
        public IActionResult GetList(List<string> sList)
        {
            var data = sList;

            return RedirectToAction("Index");
        }

        public IActionResult GetList()
        {            
            return View();
        }
    }
}
