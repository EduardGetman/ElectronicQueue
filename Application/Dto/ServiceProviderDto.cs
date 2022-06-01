using System;
using System.Collections.Generic;
using System.Linq;
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

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceProviderDto);
        }

        public bool Equals(ServiceProviderDto other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   (Queue?.Equals(other.Queue) ?? other.Queue is null) &&
                   (Services?.SequenceEqual(other.Services) ?? other.Queue is null) &&
                   (ServicePoints?.SequenceEqual(other.ServicePoints) ?? other.Queue is null);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Queue, Services, ServicePoints);
        }
        public override string ToString() => Name;
    }
}