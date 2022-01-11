using ElectronicQueue.Data.Domain.Domains.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.Queue
{
    internal class QueueConfiguration : IEntityTypeConfiguration<QueueDomain>
    {
        public void Configure(EntityTypeBuilder<QueueDomain> builder)
        {
            builder.ToTable("Queue");

            builder.Property(p => p.Letters)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(p => p.NextTicketNumber)
                   .HasDefaultValue(1)
                   .IsRequired();

            builder.Property(p => p.IsEnabled)
                   .HasDefaultValue(false);

        }
    }
}
