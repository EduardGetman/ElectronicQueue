﻿using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.StatisticDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domain.Configuration.Statistic
{
    public class WorkerStatisticsConfiguration : IEntityTypeConfiguration<WorkerStatisticsDomain>
    {
        public void Configure(EntityTypeBuilder<WorkerStatisticsDomain> builder)
        {
            builder.ToTable("WorkerStatistic");

            builder.Property(p => p.ServicedClient)
                   .IsRequired();

            builder.Property(p => p.TotalWorkDuration)
                   .IsRequired();

            builder.Property(p => p.Kind)
                   .HasDefaultValue(StatisticKind.Temporary)
                   .IsRequired();

            builder.Property(p => p.Start)
                   .IsRequired();

            builder.Property(p => p.End)
                   .IsRequired();
        }
    }
}
