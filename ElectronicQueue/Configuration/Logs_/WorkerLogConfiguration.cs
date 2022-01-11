﻿using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Configuration.Logs_
{
    public class WorkerLogConfiguration : IEntityTypeConfiguration<WorkerLogDomain>
    {
        public void Configure(EntityTypeBuilder<WorkerLogDomain> builder)
        {
            builder.ToTable("WorkerLog");

            builder.Property(p => p.EventKind)
                   .IsRequired();

            builder.Property(p => p.ServicePointName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.EventDateTime)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
