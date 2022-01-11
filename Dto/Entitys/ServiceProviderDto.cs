using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Models;
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

        public ServiceProviderDto()
        {
        }
        public ServiceProviderDto(ServiceProviderDomain domain) : base(domain)
        {
            Name = domain.Name;
        }
        public ServiceProviderDto(ServiceProviderModel model) : base(model)
        {
            Name = model.Name;
        }

        public ServiceProviderDomain ToDomain()
        {
            var domain = ToDomain<ServiceProviderDomain>();
            domain.Name = Name;
            return domain;
        }
        public ServiceProviderModel ToModel()
        {
            var domain = ToModel<ServiceProviderModel>();
            domain.Name = Name;
            return domain;
        }
        public override string ToString() => Name;
    }
}