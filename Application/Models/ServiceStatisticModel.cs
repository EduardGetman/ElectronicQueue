namespace ElectronicQueue.Core.Application.Model
{
    public class ServiceStatisticModel : ModelBase
    {
        /// <summary>
        /// Количество обслуженных клиентов
        /// </summary>
        public int ServicedClient { get; set; }
        /// <summary>
        /// Количество не обслуженных клиентов
        /// </summary>
        public int UnservicedClient { get; set; }
        /// <summary>
        /// Общая продолжительность работы
        /// </summary>
        public int TotalWorkDuration { get; set; }

        public long ServiceId { get; set; }
        public ServiceModel Service { get; set; }
    }
}
