using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ElectronicQueue.Data.Domains;

namespace ElectronicQueue.Data.Configuration
{
    class QueueConfiguration : IEntityTypeConfiguration<QueueDomain>
    {
        public void Configure(EntityTypeBuilder<QueueDomain> builder)
        {
            builder.ToTable("Queue");

            builder.Property(p => p.Letters)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(p => p.IsEnabled)
                   .HasDefaultValue(false);

            builder.Property(p => p.NumberLastTickets)
                   .HasDefaultValue(0); ;
        }
    }
}
