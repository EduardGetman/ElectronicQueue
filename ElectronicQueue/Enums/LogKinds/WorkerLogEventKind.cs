namespace ElectronicQueue.Data.Enums.LogKinds
{
    public enum WorkerLogEventKind
    {
        /// <summary>
        /// Вызвал клиента
        /// </summary>
        CallClient,        
        /// <summary>
        /// Начало оказания услуг
        /// </summary>
        StartServiced,        
        // <summary>
        /// Окончание оказания услуг
        /// </summary>
        FinishServiced
    }
}
