namespace ElectronicQueue.Data.Models
{
    public class ServiceModel: ModelBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public ulong ProviderId { get; set; }
        public ServiceProviderModel Provider { get; set; }
    }
}
