using Microsoft.EntityFrameworkCore;
using SimpleEfConfigurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    public class NewsRepository
    {
        private readonly ConfigSampleContext _sampleContext;
        public NewsRepository(ConfigSampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }


        public void RemoveNewsById(int removeBy , int id)
        {
            //پیدا کردن انتیتی بر اساس ای دی و حفظ منطقی آن با استفاده از شادو پروپرتی های
            var news = _sampleContext.News.SingleOrDefault(x => x.NewsId == id);

            if (news != null)
            {
                _sampleContext.Entry(news).Property<int>("DeleteBy").CurrentValue = removeBy;

                _sampleContext.Entry(news).Property<bool>("IsDeleted").CurrentValue = true;
            }
        }

        public News GetNewsById(int id)
        {
            var news = _sampleContext.News
                .FirstOrDefault(x => x.NewsId == id && EF.Property<bool>(x,"IsDeleted") == false);
            
            return news != null ? news : _sampleContext.News.Find(id);
        }
    }
}
