using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.Data.MockModel
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointModel
    {
        public string Location { get; set; }
        public string ServicePointState { get; set; }
        public long? ProviderId { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
        public string Continues { get; set; }
        public string UnServicedCount { get; set; }
        public string StratPeriod { get; set; }
        public string EndPeriod { get; set; }
    }
}