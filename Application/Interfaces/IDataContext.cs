using ElectronicQueue.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicQueue.Core.Application.Interfaces
{
    public interface IDataContext
    {
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

        public int SaveChanges();
    }
}
