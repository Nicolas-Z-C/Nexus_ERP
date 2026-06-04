using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;
using Nexus.Domain.Entityes.CatalogEntityes.ID;
using Nexus.Domain.Entityes.EnumSupportEntities;
using Nexus.Infrastructure.Persistence.Configurations.common;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Tenantconfiguration
{
    public class TenantConfiguration : AuditableEntityConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            //base 
            base.Configure(builder);

            builder.ToTable("Tenants");

            //VOs

            builder.OwnsOne(c => c.LegalName, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("LegalName")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.TaxID, taxID =>
            {
                taxID.Property(n => n.Value)
                .HasColumnName("TaxID")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.TenantComercialName, comercialname =>
            {
                comercialname.Property(n => n.Value)
                .HasColumnName("ComercialName")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.StreetName, street =>
            {
                street.Property(n => n.Value)
                .HasColumnName("StreetName")
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.OwnsOne(c => c.AdressNumber, adress =>
            {
                adress.Property(n => n.Value)
                .HasColumnName("AdressNumber")
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.OwnsOne(c => c.Complement, complement =>
            {
                complement.Property(n => n.Value)
                .HasColumnName("Complement")
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.OwnsOne(c => c.TenantEmail, email =>
            {
                email.Property(n => n.Value)
                .HasColumnName("TenantEmail")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.TelephoneNumber, telephone =>
            {
                telephone.Property(n => n.Value)
                .HasColumnName("TelephoneNumber")
                .HasMaxLength(50)
                .IsRequired();
            });

            //Props

            builder.Property(x => x.IsActive)
            .HasColumnName("IsActive?")
            .HasDefaultValue(true)
            .IsRequired();

            //FKs
            
            builder.HasOne<EconomicSectorEntity>()
                .WithMany()
                .HasForeignKey(x => x.EconomicSectorID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<IDType>()
                .WithMany()
                .HasForeignKey(x => x.IDType)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(x => x.City)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(x => x.Country)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Region>()
                .WithMany()
                .HasForeignKey(x => x.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.Users)
            .WithOne()
            .HasForeignKey(x => x.TenantId);

            builder.Navigation(p => p.Users)
            .HasField("_users")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}