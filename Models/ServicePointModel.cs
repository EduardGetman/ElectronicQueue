using ElectronicQueue.Data.Enums;

namespace ElectronicQueue.Data.Models
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointModel : ModelBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }
        public long? ProviderId { get; set; }
        public ServicePointModel Provider { get; set; }
    }
}