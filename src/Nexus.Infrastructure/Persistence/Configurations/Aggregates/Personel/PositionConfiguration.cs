
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.CatalogEntityes.Personel;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Personel
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");
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

            builder.HasOne<Hierarchy>()
                .WithMany()
                .HasForeignKey(x => x.HierarchyId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}