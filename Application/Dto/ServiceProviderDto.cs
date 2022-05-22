using System.Collections.Generic;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Точка предоставления услуги (кабинет, окно ...)
    /// </summary>
    public class ServiceProviderDto : DtoBase
    {
        public string Name { get; set; }
        public QueueDto Queue { get; set; }
        public ICollection<ServiceDto> Services { get; set; }
        public ICollection<ServicePointDto> ServicePoints { get; set; }
    }

}