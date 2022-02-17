using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Common.Enums.LogKinds;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;

namespace ElectronicQueue.Data.Dto.Entitys.Log_
{
    /// <summary>
    /// Логи очереди
    /// </summary>
    public class QueueLogDto : LogDtoBase
    {
        public ServiceLogEventKind EventKind { get; set; }
        public ServiceLogEventKind TicketKind { get; set; }
        public TicketState State { get; set; }
        public string TicketName { get; set; }

        public long? ServiceId { get; set; }
        public ServiceDto Service { get; set; }
    }
}
