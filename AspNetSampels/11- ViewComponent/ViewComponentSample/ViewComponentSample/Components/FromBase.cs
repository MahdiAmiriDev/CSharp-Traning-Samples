using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace ViewComponentSample.Components
{
    public class FromBase:ViewComponent
    {
        private readonly NewsDbContext _newsDbContext;
        public FromBase(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext; 
        }

        public async Task<string> InvokeAsync()
        {
            return await _newsDbContext.News.Where(x => x.Id == 1).Select(s => s.Description).FirstOrDefaultAsync();
        }
    }
}
