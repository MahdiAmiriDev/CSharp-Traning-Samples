using Microsoft.AspNetCore.Mvc;

namespace ViewComponentSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
