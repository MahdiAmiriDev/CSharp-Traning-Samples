using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Sample.Pages.Account
{
    [Authorize]
    public class UserInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
