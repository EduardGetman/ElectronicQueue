using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Domains.QueueDomain
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDomain : DomainBase
    {
        public int NextTicketNumber { get; set; }
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<TicketDomain> Tickets { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
    }
}
