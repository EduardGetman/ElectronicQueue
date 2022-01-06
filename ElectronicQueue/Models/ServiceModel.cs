using System.ComponentModel;

namespace ElectronicQueue.Data.Models
{
    public class ServiceModel : ModelBase
    {
        private string name;
        private bool isProvided;
        private ulong providerId;

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public bool IsProvided
        {
            get => isProvided; set
            {
                isProvided = value;
                OnPropertyChanged();
            }
        }
        public ulong ProviderId
        {
            get => providerId; set
            {
                providerId = value;
            }
        }
        public ServiceProviderModel Provider { get; set; }
    }
}
