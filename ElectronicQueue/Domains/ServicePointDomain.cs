using ElectronicQueue.Data.Enums;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDomain : DomainBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }
        public ulong? ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
    }
}