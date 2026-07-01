
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Personel;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Personel
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            //PK
            builder.HasKey(x => x.ID);
            //VO
            builder.OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
            });

            //FKs

            builder.HasOne<Wage>()
                .WithMany()
                .HasForeignKey(x => x.WageID)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}