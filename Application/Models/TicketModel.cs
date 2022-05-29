using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Core.Application.Model
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketModel : ModelBase
    {
        public int Number { get; set; }
        public TicketState State { get; set; }
        public DateTime TimeUpdatedState { get; set; }
        public ulong? NextTicketId { get; set; }
    }
}