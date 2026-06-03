using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Enums;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Proyect State");
            //PK
            builder.HasKey(x => x.Value);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("State")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(Currency.GetAll());
        }
    }
}