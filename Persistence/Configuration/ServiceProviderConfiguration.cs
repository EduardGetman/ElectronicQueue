using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
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
