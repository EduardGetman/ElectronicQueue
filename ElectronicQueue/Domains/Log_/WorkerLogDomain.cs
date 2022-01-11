using ElectronicQueue.Data.Common.Enums.LogKinds;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;

namespace ElectronicQueue.Data.Domain.Domains.LogDomain
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
