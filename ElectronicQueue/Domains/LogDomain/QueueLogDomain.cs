using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Логи очереди
    /// </summary>
    public class QueueLogDomain : LogDomainBase
    {        
        public ServiceLogEventKind EventKind { get; set; }
        public ServiceLogEventKind TicketKind { get; set; }
        public TicketState State { get; set; }
        public string TicketName { get; set; }

        public long? ServiceId { get; set; }
        public ServiceDomain Service { get; set; }
    }
}
