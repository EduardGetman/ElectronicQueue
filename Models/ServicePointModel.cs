using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Common.Extansion;

namespace ElectronicQueue.Data.Models
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointModel : ModelBase
    {
        private string _location;
        private ServicePointState _servicePointState;
        private long? _providerId;
        private ServiceProviderModel _provider;
        public string Location 
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        public ServicePointState ServicePointState
        {
            get => _servicePointState;
            set
            {
                _servicePointState = value;
                OnPropertyChanged();
            }
        }
        public long? ProviderId
        {
            get => _providerId;
            set
            {
                _providerId = value;
                OnPropertyChanged();
            }
        }
        public ServiceProviderModel Provider
        {
            get => _provider;
            set
            {
                _provider = value;
                OnPropertyChanged();
            }
        }

        public string ServicePointStateName => _servicePointState.ToName();
        public string ProviderName => Provider.Name;
    }
}