using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.Geography
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            
            builder.ToTable("Country");
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
            
            builder.HasOne<Continent>()
                .WithMany()
                .HasForeignKey(x => x.ContinentID)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}