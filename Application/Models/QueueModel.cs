using System.Collections.ObjectModel;

namespace ElectronicQueue.Core.Application.Models
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueModel : ModelBase
    {
        private string _letters;
        private bool _isEnabled;
        private long _providerId;
        private int _nextTicketNumber;
        private ServiceProviderModel _provider;

        public string Letters
        {
            get => _letters;
            set => Set(ref _letters, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }
        public long ProviderId
        {
            get => _providerId;
            set => Set(ref _providerId, value);
        }
        public int NextTicketNumber
        {
            get => _nextTicketNumber;
            set => Set(ref _nextTicketNumber, value);
        }
        public ServiceProviderModel Provider
        {
            get => _provider;
            set => Set(ref _provider, value);
        }
        public int TiketsCount => Tikets?.Count ?? 0;
        public string ProviderName => Provider?.Name ?? "Не определён";
        public ObservableCollection<TicketModel> Tikets { get; set; }

        public QueueModel()
        {
            Tikets = new ObservableCollection<TicketModel>();
        }
    }
}
