using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.QueueDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.Queue
{
    class TicketConfiguration : IEntityTypeConfiguration<TicketDomain>
    {
        public void Configure(EntityTypeBuilder<TicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.State)
                   .HasDefaultValue(TicketState.Waiting);

            builder.HasOne(p => p.Service)
                   .WithMany(p => p.Tickets)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(p => p.ServiceId);
        }
    }
}
