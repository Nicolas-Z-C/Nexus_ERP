using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Support;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.ToTable("Priority");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("Value")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(Priority.GetAll());
        }
    }
}