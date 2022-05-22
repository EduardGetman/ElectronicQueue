using System.Collections.Generic;

namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Точка предоставления услуги (кабинет, окно ...)
    /// </summary>
    public class ServiceProviderDomain : DomainBase
    {
        public string Name { get; set; }
        public QueueDomain Queue { get; set; }
        public ICollection<ServiceDomain> Services { get; set; }
        public ICollection<ServicePointDomain> ServicePoints { get; set; }
    }

}