using System.Collections.Generic;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Работник
    /// </summary>
    public class WorkerDto : DtoBase
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public long? PointId { get; set; }
        public ServicePointDto Point { get; set; }
        public ICollection<WorkerStatisticDto> Statistics { get; set; }
        public ICollection<WorkerLogDto> Logs { get; set; }
    }
}
