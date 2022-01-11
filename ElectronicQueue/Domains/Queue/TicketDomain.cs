﻿using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;

namespace ElectronicQueue.Data.Domain.Domains.Queue
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDomain : DomainBase
    {
        public TicketState State { get; set; }
        public long ServiceId { get; set; }
        public long QueueId { get; set; }


        public QueueDomain Queue { get; set; }
        public ServiceDomain Service { get; set; }
    }
}