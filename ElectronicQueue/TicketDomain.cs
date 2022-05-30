using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDomain : DomainBase
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public TicketState State { get; set; }
        public long ServiceId { get; set; }
        public long QueueId { get; set; }


        public QueueDomain Queue { get; set; }
        public ServiceDomain Service { get; set; }
    }
}