using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<ServiceDomain>
    {
        public void Configure(EntityTypeBuilder<ServiceDomain> builder)
        {
            builder.ToTable("Service");

            builder.Property(p => p.IsProvided)
                   .HasDefaultValue(false);

            builder.Property(p => p.Name)
                   .HasMaxLength(200)
                   .IsRequired();

        }
    }
}
