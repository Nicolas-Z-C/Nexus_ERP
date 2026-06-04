using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Entityes.Support;
using Nexus.Domain.Enums;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Personel
{
    public class WageConfiguration : IEntityTypeConfiguration<Wage>
    {
        public void Configure(EntityTypeBuilder<Wage> builder)
        {
            builder.ToTable("Positions");
            //PK
            builder.HasKey(x => x.ID);

            //properties

            builder.Property(x => x.Amount)
            .HasColumnName("Amount")
            .IsRequired();

            builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();
            
            //FKs

            builder.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(x => x.CurrencyID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<RemunerationType>()
                .WithMany()
                .HasForeignKey(x => x.RemunerationTypeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}