using ElectronicQueue.Data.Domains;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Dto
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDto : DtoBase
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public int NumberLastTickets { get; set; }
        public ulong ProviderId { get; set; }

        public QueueDto(QueueDomain domain): base(domain)
        {
            Letters = domain.Letters;
            IsEnabled = domain.IsEnabled;
            NumberLastTickets = domain.NumberLastTickets;
            ProviderId = domain.ProviderId;
        }
        public QueueDomain ToDomain()
        {
            var domain = ToDomain<QueueDomain>();
            domain.Letters = Letters;
            domain.IsEnabled = IsEnabled;
            domain.NumberLastTickets = NumberLastTickets;
            domain.ProviderId = ProviderId;
            return domain;
        }
    }
}
