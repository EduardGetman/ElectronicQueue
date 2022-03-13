namespace ElectronicQueue.Data.MockModel
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueModel
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public long? LastTicketId { get; set; }
        public string LastTicket { get; set; }
        public long ProviderId { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
        public string ServicesCount { get; set; }
        public bool IsProvided { get; set; }
    }
}
