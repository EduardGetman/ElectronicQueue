namespace ElectronicQueue.Data.Models
{
    public class ServiceModel : ModelBase
    {
        private string name;
        private bool isProvided;
        private long providerId;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public bool IsProvided
        {
            get => isProvided;
            set
            {
                isProvided = value;
                OnPropertyChanged();
            }
        }
        public long ProviderId
        {
            get => providerId;
            set
            {
                providerId = value;
            }
        }
    }
}
