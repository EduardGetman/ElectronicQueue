using ElectronicQueue.Data.Common.Enums;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Dto.Entitys.OrganizationInfo
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDto : DtoBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }

        public long? ProviderId { get; set; }
        public ServiceProviderDto Provider { get; set; }
        public ICollection<WorkerDto> Workers { get; set; }
    }
}