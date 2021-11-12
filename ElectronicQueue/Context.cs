using ElectronicQueue.Data.Configuration;
using ElectronicQueue.Data.Domains;
using Microsoft.EntityFrameworkCore;
namespace ElectronicQueue.Data
{
    public class Context : DbContext
    {
        const string ServerName = @"DESKTOP-R2OJFDB";
        const string DbName = "ElectronicQueueDb";
        public Context()
        {
            Database.EnsureCreated();
        }

        public DbSet<QueueDomain> Queues { get; set; }
        public DbSet<ServiceDomain> Services { get; set; }
        public DbSet<ServicePointDomain> ServicePoints { get; set; }
        public DbSet<ServiceProviderDomain> ServiceProviders { get; set; }
        public DbSet<TicketDomain> Tickets { get; set; }

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
        }

    }
}
