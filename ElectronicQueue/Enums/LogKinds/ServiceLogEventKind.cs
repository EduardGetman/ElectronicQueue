namespace ElectronicQueue.Data.Enums
{
    /// <summary>
    /// Тип события очереди
    /// </summary>
    public enum ServiceLogEventKind
    {
        /// <summary>
        /// Очередь запущена
        /// </summary>
        QueueStart,
        /// <summary>
        /// Очередь завершила работу
        /// </summary>
        QueueStop,
        /// <summary>
        /// Очередь приостановленна
        /// </summary>
        QueueHold,
        /// <summary>
        /// Добавлен талон
        /// </summary>
        AddTicket,
        /// <summary>
        /// Подтвержден талон
        /// </summary>
        ConfirmedTicket,
        /// <summary>
        /// Талон сменил состояние
        /// </summary>
        TicketChangeState,
        /// <summary>
        /// Талон изъят
        /// </summary>
        TicketRemoved
    }
}