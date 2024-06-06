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
    public class PrimaryKeyFluentConfig : IEntityTypeConfiguration<PrimaryKeyFlent>
    {
        public void Configure(EntityTypeBuilder<PrimaryKeyFlent> builder)
        {
            builder.HasKey(x => new {x.Pk01,x.Pk02});
        }
    }
}
