using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Support;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
    {
        public void Configure(EntityTypeBuilder<MovementType> builder)
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
            builder.HasData(MovementType.GetAll());
        }
    }
}