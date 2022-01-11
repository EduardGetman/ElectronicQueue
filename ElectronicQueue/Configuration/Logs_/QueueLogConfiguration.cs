using ElectronicQueue.Data.Domain.Domains.LogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domain.Configuration.Logs_
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
