using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Data.MockModel
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketModel
    {
        public bool isProvided;

        public int Number { get; set; }
        public string State { get; set; }
        public string TimeUpdatedState { get; set; }
        public ulong? NextTicketId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}