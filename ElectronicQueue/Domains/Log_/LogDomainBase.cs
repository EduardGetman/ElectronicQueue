using System;

namespace ElectronicQueue.Data.Domain.Domains.LogDomain
{
    /// <summary>
    /// Базовый класс логов
    /// </summary>
    public abstract class LogDomainBase : DomainBase
    {
        public DateTime EventDateTime { get; set; }
    }
}
