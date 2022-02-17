using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketDto : DtoBase
    {
        public TicketState State { get; set; }
        public long ServiceId { get; set; }
        public long QueueId { get; set; }
        public QueueDto Queue { get; set; }
        public ServiceDto Service { get; set; }
    }
}