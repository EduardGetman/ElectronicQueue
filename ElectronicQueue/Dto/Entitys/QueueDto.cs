using ElectronicQueue.Data.Domains;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDto : DtoBase
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public ulong ProviderId { get; set; }

        public QueueDto(QueueDomain domain) : base(domain)
        {
            Letters = domain.Letters;
            IsEnabled = domain.IsEnabled;
            ProviderId = domain.ProviderId;
        }
        public QueueDomain ToDomain()
        {
            var domain = ToDomain<QueueDomain>();
            domain.Letters = Letters;
            domain.IsEnabled = IsEnabled;
            domain.ProviderId = ProviderId;
            return domain;
        }
    }
}
