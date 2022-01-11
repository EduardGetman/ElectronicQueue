using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Базовый класс логов
    /// </summary>
    public abstract class LogDomainBase : DomainBase
    {
        public DateTime EventDateTime { get; set; }
    }
}
