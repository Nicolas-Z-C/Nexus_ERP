
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.Personel;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.Personel
{
    public class HierarchyConfiguration : IEntityTypeConfiguration<Hierarchy>
    {
        public void Configure(EntityTypeBuilder<Hierarchy> builder)
        {
            builder.ToTable("Hierarchy");
            //PK
            builder.HasKey(x => x.ID);
            //VO
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
            });
        }
    }
}