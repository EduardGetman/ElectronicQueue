using ElectronicQueue.Data.Domain.Domains.LogDomain;
using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Domain.Domains.Statistic;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Domains.OrganizationInfo
{
    /// <summary>
    /// Предоставляемая услуга
    /// </summary>
    public class ServiceDomain : DomainBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
        public ICollection<TicketDomain> Tickets { get; set; }
        public ICollection<QueueLogDomain> QueueLogs { get; set; }
        public ICollection<ServiceStatisticDomain> Statistics { get; set; }
    }
}