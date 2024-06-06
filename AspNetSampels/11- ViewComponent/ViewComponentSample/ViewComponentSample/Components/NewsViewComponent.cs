using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace ViewComponentSample.Components
{
    public class NewsViewComponent
    {
        private readonly NewsDbContext _newsDbContext;
        public NewsViewComponent(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }

        public async Task<string> InvokeAsync(int newsId)
        {
            var s = await _newsDbContext.News.Where(x => x.Id == newsId).Select(s => s.Description).FirstOrDefaultAsync();

            return s;
        }
    }
}
