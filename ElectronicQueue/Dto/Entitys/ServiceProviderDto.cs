using ElectronicQueue.Data.Domains;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Роль обслуживающего сервиса
    /// </summary>
    public class ServiceProviderDto : DtoBase
    {
        public string Name { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
        public ServiceProviderDto(ServiceProviderDomain domain) : base(domain)
        {
            Name = domain.Name;
        }
        public ServiceProviderDto(ServiceProviderDomain domain, IEnumerable<ServiceDto> services) : this(domain)
        {
            Services = services;
        }

        public ServiceProviderDto()
        {
        }

        public ServiceProviderDomain ToDomain()
        {
            var domain = ToDomain<ServiceProviderDomain>();
            domain.Name = Name;
            return domain;
        }
        public override string ToString() => Name;
    }
}