using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Предоставляемая услуга
    /// </summary>
    public class ServiceDto : DtoBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public ulong ProviderId { get; set; }
        public ServiceDto()
        {
        }

        public ServiceDto(ServiceModel domain) : base(domain)
        {
            Name = domain.Name;
            IsProvided = domain.IsProvided;
            ProviderId = domain.ProviderId;
        }
        public ServiceDto(ServiceDomain domain) : base(domain)
        {
            Name = domain.Name;
            IsProvided = domain.IsProvided;
            ProviderId = domain.ProviderId;
        }

        public ServiceDomain ToDomain()
        {
            var domain = ToDomain<ServiceDomain>();
            domain.Name = Name;
            domain.ProviderId = ProviderId;
            domain.IsProvided = IsProvided;
            return domain;
        }
        public ServiceModel ToModel()
        {
            var model = ToModel<ServiceModel>();
            model.Name = Name;
            model.ProviderId = ProviderId;
            model.IsProvided = IsProvided;
            return model;
        }
        public override string ToString() => Name;
    }
}