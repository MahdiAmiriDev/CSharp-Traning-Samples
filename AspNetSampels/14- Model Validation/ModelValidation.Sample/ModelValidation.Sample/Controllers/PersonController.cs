using Microsoft.AspNetCore.Mvc;
using ModelValidation.Sample.Models;

namespace ModelValidation.Sample.Controllers
{
    public class PersonController : Controller
    {
        private readonly ValidationDbContext _validationDbContext;

        public PersonController(ValidationDbContext validationDbContext)
        {
            _validationDbContext = validationDbContext;
        }
        public IActionResult Index()
        {
            return View(_validationDbContext.People.ToList());
        }

        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(SavePersonVm savePersonVm)
        {
            if (ModelState.IsValid)
            {
                _validationDbContext.People.Add(new Person
                {
                    FirstName = savePersonVm.FirstName,
                    LastName = savePersonVm.LastName,
                });
                _validationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            ModelState.AddModelError(nameof(savePersonVm.FirstName), "کاربر احمق مقدار را وارد کن");
            return View();
            
        }
    }
}
