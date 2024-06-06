using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConfigurationSamples.Models;

namespace SimpleEfConfigurationSamples.DataAccessLayer
{
    public class TypeAndNameWithFluentConfig : IEntityTypeConfiguration<TypeAndNameWithFluent>
    {
        public void Configure(EntityTypeBuilder<TypeAndNameWithFluent> builder)
        {
            builder.Property(x => x.Name).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Price).HasPrecision(14, 4);
        }
    }

    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustomerType).HasConversion<string>();

            builder.Property(x => x.Age).HasConversion(x => x.ToString(), x => int.Parse(x));
            //استفاده از کلاس اختصاصی تبدل نوع داده خواندن و نوشتن از دی بی
            builder.Property(x => x.Age).HasConversion<MyIntToStringConvertor>();
        }
    }

}
