using System;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Предоставляемая услуга
    /// </summary>
    public class ServiceDto : DtoBase
    {
        public string Name { get; set; }
        public bool IsProvided { get; set; }
        public long ProviderId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceDto);
        }

        public bool Equals(ServiceDto other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   IsProvided == other.IsProvided &&
                   ProviderId == other.ProviderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsProvided, ProviderId);
        }
        public override string ToString() => Name;
    }
}