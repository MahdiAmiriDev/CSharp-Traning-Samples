using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConfigurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            //افزودن پروپرتی های به انتیتی به صورت شادو که در دی بی ایحاد می شود ولی در کلاس انتیتی دیده نمی شود
            builder.Property<int>("DeleteBy");
            builder.Property<bool>("IsDeleted");
        }
    }
}
