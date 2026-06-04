using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.EnumSupportEntities;
using Nexus.Domain.Enums;
using Nexus.Infrastructure.Persistence.Configurations.common;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Proyectconfigurations
{
    public class ProyectConfiguration : AuditableEntityConfiguration<Proyect>
    {
        public void Configure(EntityTypeBuilder<Proyect> builder)
        {
            //base 
            base.Configure(builder);

            builder.ToTable("Staff");
            //VOs
            builder.OwnsOne(c => c.ProyectName, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
            });

            //Props

            builder.Property(x => x.Budget)
            .HasColumnName("Budget")
            .IsRequired();

            builder.Property(x => x.ContractPrice)
            .HasColumnName("Contract_price")
            .IsRequired();

            builder.Property(x => x.EstimatedProffit)
            .HasColumnName("Estimated_proffit")
            .IsRequired();

            builder.Property(x => x.EstimatedDateOfRelease)
            .HasColumnName("Estimated_date_of_release")
            .IsRequired();

            builder.Property(x => x.EstimatedDurationDays)
            .HasColumnName("Estimated_duration_in_days")
            .IsRequired();

            builder.Property(x => x.DateOfStart)
            .HasColumnName("Date_of_start")
            .IsRequired();

            builder.Property(x => x.RealDateOfRelease)
            .HasColumnName("Date_of_release")
            .IsSparse();

            builder.Property(x => x.IsDelayed)
            .HasColumnName("Is_delayed?")
            .HasDefaultValue(false)
            .IsRequired();

            builder.Property(x => x.HasLeftPlanningStage)
            .HasColumnName("Has_left_the_planning_stage?")
            .HasDefaultValue(false)
            .IsRequired();

            //FKs

            builder.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(x => x.CurrencyID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<ProyectStatusEntity>()
                .WithMany()
                .HasForeignKey(x => x.ProyectStateID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.Assignements)
            .WithOne()
            .HasForeignKey(x => x.ProyectID);

            builder.Navigation(p => p.Assignements)
            .HasField("_assignements")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}