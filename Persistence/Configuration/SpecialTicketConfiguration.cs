using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    internal class SpecialTicketConfiguration : IEntityTypeConfiguration<SpecialTicketDomain>
    {
        public void Configure(EntityTypeBuilder<SpecialTicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.IsConfirmed)
                   .HasDefaultValue(false);

            builder.Property(p => p.Info)
                   .HasMaxLength(300);
        }
    }
}
