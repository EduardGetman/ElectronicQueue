using System.Collections.Generic;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDomain : DomainBase
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public int NumberLastTickets { get; set; }
        public ServiceProviderDomain ServiceProvider { get; set; }
        public ICollection<TicketDomain> Tickets { get; set; }
    }
}
