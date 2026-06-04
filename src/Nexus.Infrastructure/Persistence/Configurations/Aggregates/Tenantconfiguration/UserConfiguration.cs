using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Infrastructure.Persistence.Configurations.common;

namespace Nexus.Infrastructure.Persistence.Configurations.Aggregates.Tenantconfiguration
{
    public class UserConfiguration : AuditableEntityConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //base 
            base.Configure(builder);

            builder.ToTable("Users");
            //VOs

            builder.OwnsOne(c => c.UserName, name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("UserName")
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsOne(c => c.UserPassword, password =>
            {
                password.Property(n => n.Value)
                .HasColumnName("Password")
                .HasMaxLength(10)
                .IsRequired();
            });

            builder.OwnsOne(c => c.ResetToken, token =>
            {
                token.Property(n => n.Value)
                .HasColumnName("Token")
                .HasMaxLength(4)
                .IsSparse();
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(n => n.Value)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
            });

            //Props

            builder.Property(x => x.IsActive)
            .HasColumnName("Is_Active?")
            .HasDefaultValue(true)
            .IsRequired();

            //FKs

            builder.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}