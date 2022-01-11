using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;

namespace ElectronicQueue.Data.Domain.Domains.Statistic
{
    public class WorkerStatisticsDomain : StatisticDomainBase
    {
        /// <summary>
        /// Количество обслуженых клиентов
        /// </summary>
        public int ServicedClient { get; set; }
        /// <summary>
        /// Общая продолжительность работы
        /// </summary>
        public int TotalWorkDuration { get; set; }
        /// <summary>
        /// Производительность. Количество обслуженых клиентов в час
        /// </summary>
        public float Productivity => TotalWorkDuration / ServicedClient * 60;

        public long WorkerId { get; set; }
        public WorkerDomain Worker { get; set; }
    }
}
