
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.EnumSupportEntities;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class PersonalStatusConfiguration : IEntityTypeConfiguration<PersonalStatusEntity>
    {
        public void Configure(EntityTypeBuilder<PersonalStatusEntity> builder)
        {
            builder.ToTable("Personel_state");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("State")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(PersonalStatusEntity.GetAll());
        }
    }
}