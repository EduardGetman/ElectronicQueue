using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Configuration
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
