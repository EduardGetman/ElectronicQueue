﻿using System.Collections.Generic;
using ElectronicQueue.Data.Domains.StatisticDomain;

namespace ElectronicQueue.Data.Domains
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