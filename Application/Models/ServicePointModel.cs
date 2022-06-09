using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.Core.Application.Models
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
            set => Set(ref _location, value);
        }
        public ServicePointState ServicePointState
        {
            get => _servicePointState;
            set => Set(ref _servicePointState, value);
        }
        public long? ProviderId
        {
            get => _providerId;
            set => Set(ref _providerId, value);
        }
        public ServiceProviderModel Provider
        {
            get => _provider;
            set => Set(ref _provider, value);
        }

        public string ServicePointStateName => ServicePointState.ToString();
        public string ProviderName => Provider?.Name ?? "Не указан";
        public override string ToString() => Location;
    }
}