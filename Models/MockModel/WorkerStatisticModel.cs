namespace ElectronicQueue.Data.MockModel
{
    public class WorkerStatisticModel
    {

        /// <summary>
        /// Количество обслуженых клиентов
        /// </summary>
        public int ServicedClient { get; set; }
        /// <summary>
        /// Общая продолжительность работы
        /// </summary>
        public int TotalWorkDuration { get; set; }
        public string Worker { get; set; }
    }
}
