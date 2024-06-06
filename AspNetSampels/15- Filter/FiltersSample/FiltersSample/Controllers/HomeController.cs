using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    public class HomeController : Controller
    {
        [MyHttps]
        public IActionResult Index()
        {
            if(Request.IsHttps)
            return View();

            return StatusCode(StatusCodes.Status403Forbidden);
        }

        [RequireHttps]
        public IActionResult About()
        {
            return View();
        }
    }
}
