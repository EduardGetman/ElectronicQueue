using ElectronicQueue.Data.Dto;
using ElectronicQueue.Data.Enums;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDto : DtoBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }
        public ulong? ProviderId { get; set; }
        public ServicePointDto(ServicePointDomain domain) : base(domain)
        {
            Location = domain.Location;
            ServicePointState = domain.ServicePointState;
            ProviderId = domain.ProviderId;
        }
        public ServicePointDomain ToDomain()
        {
            var domain = ToDomain<ServicePointDomain>();
            domain.Location = Location;
            domain.ProviderId = ProviderId;
            domain.ServicePointState = ServicePointState;
            return domain;
        }
    }
}