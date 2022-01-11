using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;

namespace ElectronicQueue.Data.Dto.Entitys.Queue
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDto : DtoBase
    {
        public int NextTicketNumber { get; set; }
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderDto Provider { get; set; }
    }
}
