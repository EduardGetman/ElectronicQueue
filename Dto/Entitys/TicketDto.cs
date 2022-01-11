using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Models;
using System;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDto : DtoBase
    {
        public int Number { get; set; }
        public TicketState State { get; set; }
        public DateTime TimeUpdatedState { get; set; }
        public TicketDto(TicketDomain domain) : base(domain)
        {
            State = domain.State;
        }
        public TicketDto(TicketModel domain) : base(domain)
        {
            Number = domain.Number;
            State = domain.State;
            TimeUpdatedState = domain.TimeUpdatedState;
        }

        public TicketDomain ToDomain()
        {
            var domain = ToDomain<TicketDomain>();
            domain.State = State;
            return domain;
        }
        public TicketModel ToModel()
        {
            var model = ToModel<TicketModel>();
            model.Number = Number;
            model.State = State;
            model.TimeUpdatedState = TimeUpdatedState;
            return model;
        }
    }
}