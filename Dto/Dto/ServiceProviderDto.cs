using ElectronicQueue.Data.Dto.Entitys.Queue;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Dto.Entitys.OrganizationInfo
{
    /// <summary>
    /// Точка предоставления услуги (кабинет, окно ...)
    /// </summary>
    public class ServiceProviderDto : DtoBase
    {
        public string Name { get; set; }
        public QueueDto Queue { get; set; }
        public ICollection<ServiceDto> Services { get; }
        public ICollection<ServicePointDto> ServicePoints { get; }
    }

}