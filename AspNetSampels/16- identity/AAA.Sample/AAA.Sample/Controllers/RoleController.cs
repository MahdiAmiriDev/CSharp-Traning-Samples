using AAA.Sample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AAA.Sample.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult List()
        {
            var roles = _roleManager.Roles.ToList();

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

                if(result.Succeeded)
                    return RedirectToAction("List");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            if (role != null)
            {
               var result = await _roleManager.DeleteAsync(role);

               // if (!result.Succeeded)
               // {
               //     foreach (var item in result.Errors)
               //     {
               //         ModelState.AddModelError(string.Empty, item.Description);
               //     }                    
               // }
            }

            return RedirectToAction("list");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var identityRole = await _roleManager.FindByIdAsync(model.Id);

                if (identityRole != null)
                {
                    identityRole.Name = model.Name;
                    var result = await _roleManager.UpdateAsync(identityRole);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("list");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,item.Description);
                    }
                }
                
            }

            return View(model);
        }
    }
}
