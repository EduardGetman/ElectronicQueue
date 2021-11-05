namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Предоставляемая услуга
    /// </summary>
    public class ServiceDomain : DomainBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public ulong ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
    }
}