using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDto : DtoBase
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public TicketState State { get; set; }
        public long ServiceId { get; set; }
        public long QueueId { get; set; }
        public long? СallingServicePointId { get; set; }

        public ServiceDto Service { get; set; }
        public ServicePointDto СallingServicePoint { get; set; }
    }
}