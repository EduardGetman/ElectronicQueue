using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.OrganizationInfo
{
    class ServicePointConfiguration : IEntityTypeConfiguration<ServicePointDomain>
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
