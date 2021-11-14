using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Configuration
{
    class TicketConfiguration : IEntityTypeConfiguration<TicketDomain>
    {
        public void Configure(EntityTypeBuilder<TicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.State).HasDefaultValue(TicketState.Waiting);

            builder.Property(p => p.TimeUpdatedState).IsRequired();

            builder.HasOne(p => p.NextTicket)
                .WithOne(p => p.PreviousTicket)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CurentTikcet_Next_Ticket");
        }
    }
}
