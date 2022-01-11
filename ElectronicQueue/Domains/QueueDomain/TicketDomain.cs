using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Domains
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