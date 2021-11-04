using System;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDomain : DomainBase
    {
        public int Number { get; set; }
        public DateTime CreateDate { get; set; }
        public TicketState State { get; set; }
        public DateTime TimeUpdatedState { get; set; }
        public QueueDomain Queue { get; set; }
    }
}