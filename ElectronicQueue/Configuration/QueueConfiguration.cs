using ElectronicQueue.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasOne(p => p.LastTicket)
                   .WithOne(p => p.Queue)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_LastTiket_Queue");
        }
    }
}
