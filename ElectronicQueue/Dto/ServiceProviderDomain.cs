using ElectronicQueue.Data.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Роль обслуживающего сервиса
    /// </summary>
    public class ServiceProviderDto : DtoBase
    {
        public string Name { get; set; }
        public ServiceProviderDto(ServiceProviderDomain domain) : base(domain)
        {
            Name = domain.Name;
        }
        public ServiceProviderDomain ToDomain()
        {
            var domain = ToDomain<ServiceProviderDomain>();
            domain.Name = Name;
            return domain;
        }
    }

}