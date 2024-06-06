using Microsoft.AspNetCore.Mvc;

namespace ModelValidation.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
