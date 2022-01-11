using ElectronicQueue.Data.Domain.Domains.QueueDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.Queue
{
    class SpecialTicketConfiguration : IEntityTypeConfiguration<SpecialTicketDomain>
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
