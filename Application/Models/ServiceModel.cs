namespace ElectronicQueue.Core.Application.Models
{
    public class ServiceModel : ModelBase
    {
        private string name;
        private bool isProvided;
        private long providerId;

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }
        public bool IsProvided
        {
            get => isProvided;
            set => Set(ref isProvided, value);
        }
        public long ProviderId
        {
            get => providerId;
            set => Set(ref providerId, value);
        }
    }
}
