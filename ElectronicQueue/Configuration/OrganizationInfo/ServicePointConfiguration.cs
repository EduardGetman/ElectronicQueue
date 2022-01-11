using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.OrganizationInfo
{
    internal class ServicePointConfiguration : IEntityTypeConfiguration<ServicePointDomain>
    {
        public void Configure(EntityTypeBuilder<ServicePointDomain> builder)
        {
            builder.ToTable("ServicePoint");

            builder.Property(p => p.Location)
                   .HasMaxLength(200);

            builder.Property(p => p.ServicePointState)
                   .HasDefaultValue(ServicePointState.Closed);
        }
    }
}
