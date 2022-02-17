using System.Collections.Generic;

namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Работник
    /// </summary>
    public class WorkerDomain : DomainBase
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public long? PointId { get; set; }
        public ServicePointDomain Point { get; set; }
        public ICollection<WorkerStatisticDomain> Statistics { get; set; }
        public ICollection<WorkerLogDomain> Logs { get; set; }
    }
}
