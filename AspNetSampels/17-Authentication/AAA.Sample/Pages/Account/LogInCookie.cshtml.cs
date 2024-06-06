using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Sample.Pages.Account
{
    public class LogInCookieModel : PageModel
    {
        public string CookieValue { get; set; }
        public void OnGet()
        {
            if (Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
            {
                CookieValue = Request.Cookies["AspNetCore.Identity.Application"];
            }
            else
            {
                CookieValue = "There is No Cookie";
            }
        }
    }
}
