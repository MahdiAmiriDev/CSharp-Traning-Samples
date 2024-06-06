using CourseStore.Model.Tags.Dto;
using CourseStore.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Tags
{
    public static class TagQueryExtionsions
    {
        public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags , string tagName)
        {
            if (!string.IsNullOrEmpty(tagName))
            {
                tags = tags.Where(x => x.TagName.Contains(tagName));
            }
            return tags;
        }

        public static  List<TagQr> ToTagQr(this IQueryable<Tag> tags)
        {
            return  tags.Select(c => new TagQr
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToList();
        }

        public static async Task<List<TagQr>> ToTagQrAsync(this IQueryable<Tag> tags)
        {
            return await tags.Select(c => new TagQr
            {
                Id = c.Id,
                TagName = c.TagName,                
            }).ToListAsync();
        }
    }
}
