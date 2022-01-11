using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.OrganizationInfo
{
    internal class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProviderDomain>
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
