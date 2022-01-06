using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDomain : DomainBase
    {
        public int Number { get; set; }
        public TicketState State { get; set; }
        public DateTime TimeUpdatedState { get; set; }
        public ulong? NextTicketId { get; set; }
        public ulong? QueueId { get; set; }
        public QueueDomain Queue { get; set; }
        public TicketDomain NextTicket { get; set; }
        public TicketDomain PreviousTicket { get; set; }
    }
}