using ElectronicQueue.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Configuration.OrganizationInfo
{
    public class WorkerConfiguration : IEntityTypeConfiguration<WorkerDomain>
    {
        public void Configure(EntityTypeBuilder<WorkerDomain> builder)
        {
            builder.ToTable("Worker");

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Specialization)
                   .HasMaxLength(200);       
        }
    }
}
