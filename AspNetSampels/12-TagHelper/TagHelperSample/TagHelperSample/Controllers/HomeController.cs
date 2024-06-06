using Microsoft.AspNetCore.Mvc;

namespace TagHelperSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
