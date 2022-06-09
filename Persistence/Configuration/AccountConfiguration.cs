using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountDomain>
    {
        public void Configure(EntityTypeBuilder<AccountDomain> builder)
        {
            builder.ToTable("Account");

            builder.Property(p => p.Login)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.PasswordHash)
                   .IsRequired();
        }
    }
}
