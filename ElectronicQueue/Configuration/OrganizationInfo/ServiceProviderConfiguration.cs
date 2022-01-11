using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.OrganizationInfo
{
    class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProviderDomain>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderDomain> builder)
        {
            builder.ToTable("ServiceProvider");

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
