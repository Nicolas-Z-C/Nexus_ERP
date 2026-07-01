
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.CatalogEntityes.ID;

namespace Nexus.Infrastructure.Persistence.Configurations.CatalogEntities.ID
{
    public class IDTypeConfiguration : IEntityTypeConfiguration<IDType>
    {
        public void Configure(EntityTypeBuilder<IDType> builder)
        {
            builder.ToTable("ID_types");
            //PK
            builder.HasKey(x => x.ID);
            //VO
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.Value)
                .HasColumnName("Type")
                .HasMaxLength(100)
                .IsRequired();
            });
        }
    }
}