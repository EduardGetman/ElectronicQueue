using ElectronicQueue.Data.Common.Enums.LogKinds;

namespace ElectronicQueue.Core.Domain
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
