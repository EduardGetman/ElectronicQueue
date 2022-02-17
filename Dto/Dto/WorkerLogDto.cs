using ElectronicQueue.Data.Common.Enums.LogKinds;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;

namespace ElectronicQueue.Data.Dto.Entitys.Log_
{
    /// <summary>
    /// Логи работы сотрудника оьслуживания
    /// </summary>
    public class WorkerLogDto : LogDtoBase
    {
        public string ServicePointName { get; set; }
        public WorkerLogEventKind EventKind { get; set; }

        public long WorkerId { get; set; }
        public WorkerDto Worker { get; set; }
    }
}
