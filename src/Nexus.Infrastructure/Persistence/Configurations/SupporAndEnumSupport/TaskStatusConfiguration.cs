using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.EnumSupportEntities;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatusEntity>
    {
        public void Configure(EntityTypeBuilder<TaskStatusEntity> builder)
        {
            builder.ToTable("Task Status");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("Status")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(TaskStatusEntity.GetAll());
        }
    }
}