using System;

namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Базовый класс логов
    /// </summary>
    public abstract class LogDomainBase : DomainBase
    {
        public DateTime EventDateTime { get; set; }
    }
}
