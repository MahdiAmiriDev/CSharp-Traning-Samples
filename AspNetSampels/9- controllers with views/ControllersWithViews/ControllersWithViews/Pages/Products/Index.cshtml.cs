using ControllersWithViews.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControllersWithViews.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PepoleDbContext pepoleDbContext;
        public Pepole Person { get; set; }
        public List<Pepole> Pepole { get; set; }
        public IndexModel(PepoleDbContext pepoleDbContext)
        {
            this.pepoleDbContext = pepoleDbContext;
        }

        public void OnGet(int count = 1)
        {
            //Person = pepoleDbContext.Pepole.First();
            Pepole = pepoleDbContext.Pepole.Take(count).ToList();

        }

        public string GetTime() => DateTime.Now.ToLongTimeString();
    }
}
