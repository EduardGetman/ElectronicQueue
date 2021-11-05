using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ElectronicQueue.Data.Domains;

namespace ElectronicQueue.Data.Configuration
{
    class ServiceConfiguration : IEntityTypeConfiguration<ServiceDomain>
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
