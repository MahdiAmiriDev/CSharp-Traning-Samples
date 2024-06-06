using Microsoft.AspNetCore.Mvc;

namespace AAA.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
