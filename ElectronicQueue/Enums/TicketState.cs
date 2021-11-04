namespace ElectronicQueue.Data
{
    public enum TicketState
    {
        /// <summary>
        /// Ожидает вызова
        /// </summary>
        Waiting,
        /// <summary>
        /// Вызван
        /// </summary>
        Called,
        /// <summary>
        /// Обслуживается
        /// </summary>
        Serviced,
        /// <summary>
        /// Обслужен
        /// </summary>
        Closed
    }
}