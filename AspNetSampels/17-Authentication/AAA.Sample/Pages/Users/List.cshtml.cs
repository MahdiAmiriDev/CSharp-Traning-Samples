using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAA.Sample.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IEnumerable<IdentityUser> users { get; set; } = Enumerable.Empty<IdentityUser>();
        public ListModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet() 
        {
            users = _userManager.Users.ToList();
        }
    }
}
