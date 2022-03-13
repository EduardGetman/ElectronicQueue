namespace ElectronicQueue.Data.MockModel
{
    public class ServiceStatisticModel
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
        public string Service { get; set; }
        public string Name { get; set; }
        public string Continues { get; set; }
        public string UnServicedCount { get; set; }
        public string StratPeriod { get; set; }
        public string EndPeriod { get; set; }
        public string ClientCount { get; set; }
    }
}
