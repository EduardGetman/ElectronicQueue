using System.Collections.Generic;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Предоставляемая услуга
    /// </summary>
    public class ServiceDto : DtoBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderDto Provider { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
        public ICollection<QueueLogDto> QueueLogs { get; set; }
        public ICollection<ServiceStatisticDto> Statistics { get; set; }
    }
}