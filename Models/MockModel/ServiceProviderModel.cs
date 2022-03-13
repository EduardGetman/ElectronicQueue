using System.Collections.Generic;

namespace ElectronicQueue.Data.MockModel
{
    public class ServiceProviderModel
    {
        public string Name { get; set; }
        public string Queue { get; set; }
        public string[] Services { get; }
        public string[] ServicePoints { get; }
        public bool IsProvided { get; set; }
        public string ServicesCount { get; set; }
    }
}
