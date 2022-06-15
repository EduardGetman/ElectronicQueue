using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Infrastructure.Persistence.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<WorkerDomain>
    {
        public void Configure(EntityTypeBuilder<WorkerDomain> builder)
        {
            builder.ToTable("Worker");

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
