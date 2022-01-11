using ElectronicQueue.Data.Domain.Domains.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.Queue
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
