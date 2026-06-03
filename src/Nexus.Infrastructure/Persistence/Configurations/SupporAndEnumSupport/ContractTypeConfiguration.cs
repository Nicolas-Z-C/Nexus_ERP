
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.EnumSupportEntities;

namespace Nexus.Infrastructure.Persistence.Configurations.SupporAndEnumSupport
{
    public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContractTypeEntity> builder)
        {
            builder.ToTable("Contract Types");
            //PK
            builder.HasKey(x => x.Id);
            //PropertyName
            builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
            //Seeding
            builder.HasData(ContractTypeEntity.GetAll());
        }
    }
}