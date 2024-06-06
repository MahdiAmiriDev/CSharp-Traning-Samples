using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViews.Controllers
{
    public class TmpController : Controller
    {
        public IActionResult Index()
        {
            TempData["kitty"] = "hello kitty !";

            return RedirectToAction("TestTmp");
        }

        public IActionResult TestTmp()
        {
            //TempData.Keep("kitty");
            var test = TempData.Peek("kitty");

            return View(test);
        }
    }
}
