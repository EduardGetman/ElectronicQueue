using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.Statistic
{
    public class WorkerStatisticsConfiguration : IEntityTypeConfiguration<WorkerStatisticDomain>
    {
        public void Configure(EntityTypeBuilder<WorkerStatisticDomain> builder)
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
