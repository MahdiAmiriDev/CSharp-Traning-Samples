using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace ViewComponentSample.Components
{
    public class NewsList:ViewComponent
    {
        private readonly NewsDbContext _newsDbContext;

        [ViewComponentContext]
        public ViewComponentContext vcc { get; set; }


        public NewsList(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news =await _newsDbContext.News.ToListAsync();

            return View("NewsList",news);
        }
    }
}
