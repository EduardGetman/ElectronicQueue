using System.Collections.Generic;

namespace ElectronicQueue.Data.Models
{
    public class ServiceProviderModel : ModelBase
    {
        public string Name { get; set; }
        public QueueModel Queue { get; set; }
        public ICollection<ServiceModel> Services { get; }
        public ICollection<ServicePointModel> ServicePoints { get; }
    }
}
