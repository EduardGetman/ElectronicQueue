using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Configuration
{
    class SpecialTicketConfiguration : IEntityTypeConfiguration<SpecialTicketDomain>
    {
        public void Configure(EntityTypeBuilder<SpecialTicketDomain> builder)
        {
            builder.ToTable("Ticket");

            builder.Property(p => p.IsConfirmed)
                   .HasDefaultValue(false);

            builder.Property(p => p.Info)
                   .HasMaxLength(300);
        }
    }
}
