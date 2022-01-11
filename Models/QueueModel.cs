namespace ElectronicQueue.Data.Models
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueModel : ModelBase
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public long? LastTicketId { get; set; }
        public TicketModel LastTicket { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderModel Provider { get; set; }
    }
}
