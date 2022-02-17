﻿// <auto-generated />
using System;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicQueue.Data.Migrations
{
    [DbContext(typeof(EqDbContext))]
    partial class EqDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicQueue.Data.Domains.QueueDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.QueueLogDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServiceDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServicePointDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServiceProviderDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.StatisticDomain.ServiceStatisticDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.StatisticDomain.WorkerStatisticsDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.TicketDomain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
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

                    b.HasKey("Id");

                    b.HasIndex("QueueId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Ticket");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TicketDomain");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.WorkerDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.WorkerLogDomain", b =>
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

            modelBuilder.Entity("ElectronicQueue.Data.Domains.SpecialTicketDomain", b =>
                {
                    b.HasBaseType("ElectronicQueue.Data.Domains.TicketDomain");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("SpecialTicketDomain");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.QueueDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServiceProviderDomain", "Provider")
                        .WithOne("Queue")
                        .HasForeignKey("ElectronicQueue.Data.Domains.QueueDomain", "ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.QueueLogDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServiceDomain", "Service")
                        .WithMany("QueueLogs")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServiceDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServiceProviderDomain", "Provider")
                        .WithMany("Services")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServicePointDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServiceProviderDomain", "Provider")
                        .WithMany("ServicePoints")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.StatisticDomain.ServiceStatisticDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServiceDomain", "Service")
                        .WithMany("Statistics")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.StatisticDomain.WorkerStatisticsDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.WorkerDomain", "Worker")
                        .WithMany("Statistics")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.TicketDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.QueueDomain", "Queue")
                        .WithMany("Tickets")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicQueue.Data.Domains.ServiceDomain", "Service")
                        .WithMany("Tickets")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Queue");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.WorkerDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.ServicePointDomain", "Point")
                        .WithMany("Workers")
                        .HasForeignKey("PointId");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.WorkerLogDomain", b =>
                {
                    b.HasOne("ElectronicQueue.Data.Domains.WorkerDomain", "Worker")
                        .WithMany("Logs")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.QueueDomain", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServiceDomain", b =>
                {
                    b.Navigation("QueueLogs");

                    b.Navigation("Statistics");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServicePointDomain", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.ServiceProviderDomain", b =>
                {
                    b.Navigation("Queue");

                    b.Navigation("ServicePoints");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ElectronicQueue.Data.Domains.WorkerDomain", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
