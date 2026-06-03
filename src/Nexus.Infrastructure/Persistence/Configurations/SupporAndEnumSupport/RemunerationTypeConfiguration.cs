using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Support;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class RemunerationTypeConfiguration : IEntityTypeConfiguration<RemunerationType>
    {
        public void Configure(EntityTypeBuilder<RemunerationType> builder)
        {
            builder.ToTable("Remuneration_Type");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("Type")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(RemunerationType.GetAll());
        }
    }
}