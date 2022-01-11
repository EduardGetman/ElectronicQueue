using ElectronicQueue.Data.Enums.LogKinds;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Логи работы сотрудника оьслуживания
    /// </summary>
    public class WorkerLogDomain : LogDomainBase
    {
        public string ServicePointName { get; set; }
        public WorkerLogEventKind EventKind { get; set; }

        public long WorkerId { get; set; }
        public WorkerDomain Worker { get; set; }
    }
}
