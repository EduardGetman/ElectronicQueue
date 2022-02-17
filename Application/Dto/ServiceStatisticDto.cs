namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Статистика услуги за период времени
    /// </summary>
    public class ServiceStatisticDto : StatisticDtoBase
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
        public ServiceDto Service { get; set; }
    }
}
