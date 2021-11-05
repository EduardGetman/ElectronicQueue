using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Configuration
{
    class TicketConfiguration : IEntityTypeConfiguration<TicketDomain>
    {
        public void Configure(EntityTypeBuilder<TicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.State).HasDefaultValue(TicketState.Waiting);

            builder.Property(p => p.TimeUpdatedState).IsRequired();
        }
    }
}
