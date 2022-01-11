using ElectronicQueue.Data.Domains.StatisticDomain;
using ElectronicQueue.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Configuration.Logs_
{
    public class ServiceStatisticConfiguration : IEntityTypeConfiguration<ServiceStatisticDomain>
    {
        public void Configure(EntityTypeBuilder<ServiceStatisticDomain> builder)
        {
            builder.ToTable("ServiceStatistic");

            builder.Property(p => p.ServicedClient)
                   .IsRequired();

            builder.Property(p => p.UnservicedClient)
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
