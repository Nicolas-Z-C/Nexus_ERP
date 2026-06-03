using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Catalog.Support;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class EconomicSectorConfiguration : IEntityTypeConfiguration<EconomicSectorEntity>
    {
        public void Configure(EntityTypeBuilder<EconomicSectorEntity> builder)
        {
            builder.ToTable("Economic Sector");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(EconomicSectorEntity.GetAll());
        }
    }
}