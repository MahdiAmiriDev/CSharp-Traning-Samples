using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConfigurationSamples.Models;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Ignore(x => x.Contacts);

            builder.Property(x => x.FirtName).HasMaxLength(50);
        }
    }
}
