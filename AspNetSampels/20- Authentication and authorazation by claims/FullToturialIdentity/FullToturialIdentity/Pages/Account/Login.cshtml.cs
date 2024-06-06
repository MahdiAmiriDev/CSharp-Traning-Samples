using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FullToturialIdentity.Pages.Account
{
    public class LogingModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //برمیکرده به هین صفحه انکار زدیم ریترن ویو خود اسم صفحه را میدونه
            if (!ModelState.IsValid)
                return Page();

            if(Credential.UserName== "admin" && Credential.Password== "1qaz")
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name, Credential.UserName),
                    new Claim(ClaimTypes.Email,"mahdiamirigamefa@gmail.com"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", "true"),
                    new Claim("EmploymentDate", "2023-12-03"),
                };
                 
                ClaimsIdentity identity = new ClaimsIdentity(claims, "ByCookie");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    IsPersistent = Credential.RememberMe
                };

                //تبدیل کلیم ها به آبجکت و تبدیل آبجکت به رمزنکاری شده
                //و ذخیره به عنوان کوکی در کانتکس پاسخ
                await HttpContext.SignInAsync("ByCookie", principal, properties);

                return RedirectToPage("/Index");
            }
            return Page(); 
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
