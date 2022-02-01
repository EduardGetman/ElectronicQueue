using System.Collections.Generic;

namespace ElectronicQueue.Data.Models
{
    public class WorkerStatisticModel : ModelBase
    {

        /// <summary>
        /// Количество обслуженых клиентов
        /// </summary>
        public int ServicedClient { get; set; }
        /// <summary>
        /// Общая продолжительность работы
        /// </summary>
        public int TotalWorkDuration { get; set; }
        public WorkerModel Worker { get; set; }
    }
}
