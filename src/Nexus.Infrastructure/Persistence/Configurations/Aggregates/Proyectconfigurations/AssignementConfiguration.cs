
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.EnumSupportEntities;
using Nexus.Domain.Entityes.Support;
using Nexus.Infrastructure.Persistence.Configurations.common;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Proyectconfigurations
{
    public class AssignementConfiguration : AuditableEntityConfiguration<Assignement>
    {
        public void Configure(EntityTypeBuilder<Assignement> builder)
        {
            //base

            base.Configure(builder);

            builder.ToTable("Assignements");

            //VOs

            builder.OwnsOne(c => c.TaskName, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("TaskName")
                .HasMaxLength(100)
                .IsRequired();
            });

            //Props

            builder.Property(x => x.DeadLine)
            .HasColumnName("DeadLine")
            .IsRequired();

            builder.Property(x => x.ReprogrammedFlag)
            .HasColumnName("Is_Reprogramed?")
            .HasDefaultValue(false)
            .IsRequired();

            builder.Property(x => x.OverdueFlag)
            .HasColumnName("Is_Overdue?")
            .HasDefaultValue(false)
            .IsRequired();

            //FKs

            builder.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<TaskStatusEntity>()
                .WithMany()
                .HasForeignKey(x => x.TaskStatusID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Proyect>()
                .WithMany()
                .HasForeignKey(x => x.ProyectID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Priority>()
                .WithMany()
                .HasForeignKey(x => x.PriorityID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Staff>()
                .WithMany()
                .HasForeignKey(x => x.StaffAssigned)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}