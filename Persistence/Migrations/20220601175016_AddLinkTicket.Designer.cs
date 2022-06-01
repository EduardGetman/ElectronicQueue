﻿// <auto-generated />
using System;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicQueue.Data.Migrations
{
    [DbContext(typeof(EqDbContext))]
    [Migration("20220601175016_AddLinkTicket")]
    partial class AddLinkTicket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicQueue.Core.Domain.QueueDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Letters")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("NextTicketNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId")
                        .IsUnique();

                    b.ToTable("Queue");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.QueueLogDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("EventKind")
                        .HasColumnType("int");

                    b.Property<long?>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TicketKind")
                        .HasColumnType("int");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("QueueLog");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsProvided")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServicePointDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long?>("ProviderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ServicePointState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("ServicePoint");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceProviderDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ServiceProvider");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceStatisticDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kind")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<int>("ServicedClient")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalWorkDuration")
                        .HasColumnType("int");

                    b.Property<int>("UnservicedClient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceStatistic");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.TicketDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("QueueId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<long?>("СallingServicePointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QueueId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("СallingServicePointId");

                    b.ToTable("Ticket");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TicketDomain");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("PointId")
                        .HasColumnType("bigint");

                    b.Property<string>("Specialization")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerLogDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("EventKind")
                        .HasColumnType("int");

                    b.Property<string>("ServicePointName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerLog");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerStatisticDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kind")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ServicedClient")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalWorkDuration")
                        .HasColumnType("int");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerStatistic");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.SpecialTicketDomain", b =>
                {
                    b.HasBaseType("ElectronicQueue.Core.Domain.TicketDomain");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("SpecialTicketDomain");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.QueueDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServiceProviderDomain", "Provider")
                        .WithOne("Queue")
                        .HasForeignKey("ElectronicQueue.Core.Domain.QueueDomain", "ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.QueueLogDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServiceDomain", "Service")
                        .WithMany("QueueLogs")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServiceProviderDomain", "Provider")
                        .WithMany("Services")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServicePointDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServiceProviderDomain", "Provider")
                        .WithMany("ServicePoints")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceStatisticDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServiceDomain", "Service")
                        .WithMany("Statistics")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.TicketDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.QueueDomain", "Queue")
                        .WithMany("Tickets")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicQueue.Core.Domain.ServiceDomain", "Service")
                        .WithMany("Tickets")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ElectronicQueue.Core.Domain.ServicePointDomain", "СallingServicePoint")
                        .WithMany()
                        .HasForeignKey("СallingServicePointId");

                    b.Navigation("Queue");

                    b.Navigation("Service");

                    b.Navigation("СallingServicePoint");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.ServicePointDomain", "Point")
                        .WithMany("Workers")
                        .HasForeignKey("PointId");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerLogDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.WorkerDomain", "Worker")
                        .WithMany("Logs")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerStatisticDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Core.Domain.WorkerDomain", "Worker")
                        .WithMany("Statistics")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.QueueDomain", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceDomain", b =>
                {
                    b.Navigation("QueueLogs");

                    b.Navigation("Statistics");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServicePointDomain", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.ServiceProviderDomain", b =>
                {
                    b.Navigation("Queue");

                    b.Navigation("ServicePoints");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ElectronicQueue.Core.Domain.WorkerDomain", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
