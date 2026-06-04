using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.Inventory;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.Inventory
{
    public class ObjectTypeConfiguration : IEntityTypeConfiguration<ObjectType>
    {
        public void Configure(EntityTypeBuilder<ObjectType> builder)
        {
            builder.ToTable("Object_type");
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