using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAA.Sample.Pages.Users
{
    [Authorize(Roles ="Admin")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(UserManager<IdentityUser> userManager)
        { 
            _userManager = userManager;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            IdentityUser user = new()
            {
                UserName = UserName,
                Email = Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user,Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
                return Page(); 
            }

            return RedirectToPage("List");            
        }
    }
}
