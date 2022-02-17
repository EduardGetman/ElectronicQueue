namespace ElectronicQueue.Core.Application.Dto
{
    public class WorkerStatisticDto : StatisticDtoBase
    {
        /// <summary>
        /// Количество обслуженых клиентов
        /// </summary>
        public int ServicedClient { get; set; }
        /// <summary>
        /// Общая продолжительность работы
        /// </summary>
        public int TotalWorkDuration { get; set; }

        public long WorkerId { get; set; }
        public WorkerDto Worker { get; set; }
    }
}
