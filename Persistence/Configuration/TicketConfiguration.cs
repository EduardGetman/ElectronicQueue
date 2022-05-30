using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    internal class TicketConfiguration : IEntityTypeConfiguration<TicketDomain>
    {
        public void Configure(EntityTypeBuilder<TicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.CreateTime)
                   .HasDefaultValueSql("getdate()")
                   .IsRequired();

            builder.Property(p => p.State)
                   .HasDefaultValue(TicketState.Waiting);

            builder.HasOne(p => p.Service)
                   .WithMany(p => p.Tickets)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(p => p.ServiceId);
        }
    }
}
