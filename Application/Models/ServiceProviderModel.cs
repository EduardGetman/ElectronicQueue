using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.Core.Application.Models
{
    public class ServiceProviderModel : ModelBase
    {
        private string name;

        public ServiceProviderModel()
        {
            Services = new ObservableCollection<ServiceModel>();
        }

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }
        public int ServicesCount => Services?.Count ?? 0;
        public bool IsProvided => Services?.Where(x => x.IsProvided).Any() ?? false;
        public ObservableCollection<ServiceModel> Services { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
