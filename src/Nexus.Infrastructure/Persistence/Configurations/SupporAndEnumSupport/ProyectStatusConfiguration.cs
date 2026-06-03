using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.EnumSupportEntities;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class ProyectStatusConfiguration : IEntityTypeConfiguration<ProyectStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ProyectStatusEntity> builder)
        {
            builder.ToTable("Proyect_State");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("State")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(ProyectStatusEntity.GetAll());
        }
    }
}