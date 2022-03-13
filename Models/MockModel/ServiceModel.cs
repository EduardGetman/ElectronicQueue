namespace ElectronicQueue.Data.MockModel
{
    public class ServiceModel 
    {
        private string name;
        private bool isProvided;
        private long providerId;

        public string Name
        {
            get => name; set
            {
                name = value;
            }
        }
        public bool IsProvided
        {
            get => isProvided; set
            {
                isProvided = value;
            }
        }
        public long ProviderId
        {
            get => providerId; set
            {
                providerId = value;
            }
        }
        public ServiceProviderModel Provider { get; set; }
    }
}
