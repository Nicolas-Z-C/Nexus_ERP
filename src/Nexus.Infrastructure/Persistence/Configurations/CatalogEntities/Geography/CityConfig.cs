
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.Geography
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            //PK
            builder.HasKey(x => x.ID);
            //VO
            builder.OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
            });

            //FKs

            builder.HasOne<Region>()
                .WithMany()
                .HasForeignKey(x => x.RegionID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(x => x.CountryID)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}