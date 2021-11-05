namespace ElectronicQueue.Data.Enums
{
    public enum ServicePointState
    {
        /// <summary>
        /// Не работает
        /// </summary>
        Closed,
        /// <summary>
        /// Свободен
        /// </summary>
        Free,
        /// <summary>
        /// Ожидает клиента
        /// </summary>
        WaitNext,
        /// <summary>
        /// Обслуживает
        /// </summary>
        Servicing,
        /// <summary>
        /// Обслуживание приостановленно
        /// </summary>
        Paused
    }
}