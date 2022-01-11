using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;

namespace ElectronicQueue.Data.Dto.Entitys.Queue
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