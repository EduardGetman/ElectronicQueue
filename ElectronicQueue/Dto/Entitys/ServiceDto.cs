using ElectronicQueue.Data.Domains;

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
        public ServiceDto(ServiceDomain domain) : base(domain)
        {
            Name = domain.Name;
            IsProvided = domain.IsProvided;
            ProviderId = domain.ProviderId;
        }

        public ServiceDto()
        {
        }

        public ServiceDomain ToDomain()
        {
            var domain = ToDomain<ServiceDomain>();
            domain.Name = Name;
            domain.ProviderId = ProviderId;
            domain.IsProvided = IsProvided;
            return domain;
        }
        public override string ToString() => Name;
    }
}