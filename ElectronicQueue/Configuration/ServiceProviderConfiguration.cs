using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ElectronicQueue.Data.Domains;

namespace ElectronicQueue.Data.Configuration
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
