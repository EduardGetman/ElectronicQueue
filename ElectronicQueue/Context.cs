using ElectronicQueue.Data.Domain.Configuration.Logs_;
using ElectronicQueue.Data.Domain.Configuration.OrganizationInfo;
using ElectronicQueue.Data.Domain.Configuration.Queue;
using ElectronicQueue.Data.Domain.Configuration.Statistic;
using ElectronicQueue.Data.Domain.Domains.LogDomain;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;
using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Domain.Domains.Statistic;
using Microsoft.EntityFrameworkCore;

namespace ElectronicQueue.Data.Domain
{
    public class EqDbContext : DbContext
    {
        private const string ServerName = @"DESKTOP-SAKIRQV\SQLEXPRESS";
        private const string DbName = "ElectronicQueueDb";
        //public Context()
        //{
        //    //Database.EnsureCreated();
        //}

        public DbSet<QueueDomain> Queues { get; set; }
        public DbSet<ServiceDomain> Services { get; set; }
        public DbSet<ServicePointDomain> ServicePoints { get; set; }
        public DbSet<ServiceProviderDomain> ServiceProviders { get; set; }
        public DbSet<TicketDomain> Tickets { get; set; }
        public DbSet<QueueLogDomain> QueueLogs { get; set; }
        public DbSet<WorkerDomain> Worker { get; set; }
        public DbSet<WorkerLogDomain> WorkerLogs { get; set; }
        public DbSet<WorkerStatisticDomain> WorkerStatistics { get; set; }
        public DbSet<ServiceStatisticDomain> ServiceStatistics { get; set; }
        public DbSet<SpecialTicketDomain> SpecialTickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server={ServerName};Database={DbName};Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QueueConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServicePointConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerLogConfiguration());
            modelBuilder.ApplyConfiguration(new QueueLogConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceStatisticConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerStatisticsConfiguration());
        }

    }
}
