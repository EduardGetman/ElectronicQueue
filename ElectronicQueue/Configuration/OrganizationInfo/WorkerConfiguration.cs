﻿using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicQueue.Data.Domain.Configuration.OrganizationInfo
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