using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
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
