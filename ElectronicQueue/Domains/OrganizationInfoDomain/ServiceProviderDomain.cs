using ElectronicQueue.Data.Domains;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain
{
    /// <summary>
    /// Точка предоставления услуги (кабинет, окно ...)
    /// </summary>
    public class ServiceProviderDomain : DomainBase
    {
        public string Name { get; set; }
        public QueueDomain Queue { get; set; }
        public ICollection<ServiceDomain> Services { get; }
        public ICollection<ServicePointDomain> ServicePoints { get; }
    }

}