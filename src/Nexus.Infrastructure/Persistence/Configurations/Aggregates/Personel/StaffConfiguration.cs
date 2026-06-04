
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;
using Nexus.Domain.Entityes.EnumSupportEntities;
using Nexus.Infrastructure.Persistence.Configurations.common;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Personel
{
    public class StaffConfiguration : AuditableEntityConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            //base

            base.Configure(builder);

            builder.ToTable("Staff");

            //VOs
            
            builder.OwnsOne(c => c.LegalName, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.StaffID, staffid =>
            {
                staffid.Property(n => n.Value)
                .HasColumnName("staffid")
                .HasMaxLength(20)
                .IsRequired();
            });
            
            builder.OwnsOne(c => c.StreetName, street =>
            {
                street.Property(n => n.Value)
                .HasColumnName("streetName")
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.OwnsOne(c => c.AdressNumber, adressnumber =>
            {
                adressnumber.Property(n => n.Value)
                .HasColumnName("AdressNumber")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.Complement, complement =>
            {
                complement.Property(n => n.Value)
                .HasColumnName("Complement")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(n => n.Value)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.TelephoneNumber, telephone =>
            {
                telephone.Property(n => n.Value)
                .HasColumnName("TelephoneNumber")
                .HasMaxLength(18)
                .IsRequired();
            });

            //Props

            builder.Property(x => x.DateOfJoining)
            .HasColumnName("Date_of_joining")
            .IsRequired();

            builder.Property(x => x.WorkedHoursTotal)
            .HasColumnName("Total_of_worked hours")
            .IsRequired();

            builder.Property(x => x.WeeklyWorkdedHours)
            .HasColumnName("Total_of_worked_hours_this_week")
            .IsRequired();

            builder.Property(x => x.MontlyWorkdedHours)
            .HasColumnName("Total_of_worked_hours_this_month")
            .IsRequired();

            builder.Property(x => x.IsFired)
            .HasColumnName("Is_Fired?")
            .IsRequired();

            builder.Property(x => x.IsReEmployed)
            .HasColumnName("Is_Reemployed?")
            .IsRequired();

            //FKs

            builder.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<PersonalStatusEntity>()
                .WithMany()
                .HasForeignKey(x => x.StaffStatusID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Position>()
                .WithMany()
                .HasForeignKey(x => x.PositionID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Contract>()
                .WithMany()
                .HasForeignKey(x => x.ContractID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(x => x.CityID)
                .OnDelete(DeleteBehavior.Restrict);
            
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