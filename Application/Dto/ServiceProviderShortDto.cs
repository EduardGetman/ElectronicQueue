using System;
namespace ElectronicQueue.Core.Application.Dto
{
    public class ServiceProviderShortDto : DtoBase
    {
        public string Name { get; set; }
        public override bool Equals(object obj) => Equals(obj as ServiceProviderDto);
        public bool Equals(ServiceProviderDto other) => other != null
                                                        && Id == other.Id
                                                        && Name == other.Name;
        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }

}