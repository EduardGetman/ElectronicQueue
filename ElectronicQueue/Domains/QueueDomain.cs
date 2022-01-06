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
        public ICollection<TicketDomain> Tickets { get; set; }
        public ulong ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
    }
}
