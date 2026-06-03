using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Enums;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            //PK
            builder.HasKey(x => x.Value);
            //Properties
            builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.Code)
            .HasColumnName("Code")
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(x => x.Symbol)
            .HasColumnName("Symbol")
            .HasMaxLength(1)
            .IsRequired();

            builder.Property(x => x.Decimals)
            .HasColumnName("Decimals")
            .IsRequired();
            
            //Seeding
            builder.HasData(Currency.GetAll());
        }
    }
}