using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FullToturialIdentity.Pages
{
    [Authorize(Policy = "HasHrRole")]
    public class HrPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
