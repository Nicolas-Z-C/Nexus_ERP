using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.Geography
{
    public class ContinentConfiguration : IEntityTypeConfiguration<Continent>
    {
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            builder.ToTable("Continent");
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
        }
    }
}