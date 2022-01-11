using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domains.StatisticDomain
{
    /// <summary>
    /// Статистика услуги за период времени
    /// </summary>
    public class ServiceStatisticDomain : StatisticDomainBase
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
        /// <summary>
        /// Обще количество клиентов
        /// </summary>
        public int ClientCount => ServicedClient + UnservicedClient;
        /// <summary>
        /// Нагрузка в час
        /// </summary>
        public float LoadPerHours => ClientCount / (TotalWorkDuration * 60);

        public long ServiceId { get; set; }
        public ServiceDomain Service { get; set; }
    }
}
