using ElectronicQueue.Data.Domains.StatisticDomain;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Работник
    /// </summary>
    public class WorkerDomain: DomainBase
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public long? PointId { get; set; }
        public ServicePointDomain Point { get; set; }
        public ICollection<WorkerStatisticsDomain> Statistics { get; set; }
        public ICollection<WorkerLogDomain> Logs { get; set; }
    }
}
