﻿using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    public class QueueLogConfiguration : IEntityTypeConfiguration<QueueLogDomain>
    {
        public void Configure(EntityTypeBuilder<QueueLogDomain> builder)
        {
            builder.ToTable("QueueLog");

            builder.Property(p => p.EventKind)
                   .IsRequired();

            builder.Property(p => p.TicketName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.State)
                   .IsRequired();

            builder.Property(p => p.EventDateTime)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
