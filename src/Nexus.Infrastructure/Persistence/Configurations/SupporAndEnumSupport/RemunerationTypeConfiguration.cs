using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Support;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class RemunerationTypeConfiguration : IEntityTypeConfiguration<RemunerationType>
    {
        public void Configure(EntityTypeBuilder<RemunerationType> builder)
        {
            builder.ToTable("Proyect State");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("State")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(RemunerationType.GetAll());
        }
    }
}