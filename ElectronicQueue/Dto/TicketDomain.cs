using ElectronicQueue.Data.Dto;
using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDto : DtoBase
    {
        public int Number { get; set; }
        public TicketState State { get; set; }
        public DateTime TimeUpdatedState { get; set; }
        public ulong QueueId { get; set; }
        public TicketDto(TicketDomain domain) : base(domain)
        {
            Number = domain.Number;
            State = domain.State;
            TimeUpdatedState = domain.TimeUpdatedState;
            QueueId = domain.QueueId;
        }
        public TicketDomain ToDomain()
        {
            var domain = ToDomain<TicketDomain>();
            domain.Number = Number;
            domain.State = State;
            domain.TimeUpdatedState = TimeUpdatedState;
            domain.QueueId = QueueId;
            return domain;
        }
    }
}