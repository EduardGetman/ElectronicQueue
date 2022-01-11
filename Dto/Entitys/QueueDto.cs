using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDto : DtoBase
    {
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public long ProviderId { get; set; }

        public QueueDto(QueueDomain domain) : base(domain)
        {
            Letters = domain.Letters;
            IsEnabled = domain.IsEnabled;
            ProviderId = domain.ProviderId;
        }
        public QueueDto(QueueModel model) : base(model)
        {
            Letters = model.Letters;
            IsEnabled = model.IsEnabled;
            ProviderId = model.ProviderId;
        }

        public QueueDomain ToDomain()
        {
            var domain = ToDomain<QueueDomain>();
            domain.Letters = Letters;
            domain.IsEnabled = IsEnabled;
            domain.ProviderId = ProviderId;
            return domain;
        }
        public QueueModel ToModel()
        {
            var model = ToModel<QueueModel>();
            model.Letters = Letters;
            model.IsEnabled = IsEnabled;
            model.ProviderId = ProviderId;
            return model;
        }
    }
}
