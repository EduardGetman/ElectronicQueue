using System.Collections.Generic;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Роль обслуживающего сервиса
    /// </summary>
    public class ServiceProviderDomain : DomainBase
    {
        public string Name { get; set; }
        public QueueDomain Queue { get; set; }
        public ICollection<ServiceDomain> Services { get; }
        public ICollection<ServicePointDomain> ServicePoints { get; }
    }

}