﻿using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
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
