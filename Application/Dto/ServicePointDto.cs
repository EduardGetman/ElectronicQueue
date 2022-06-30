using ElectronicQueue.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDto : DtoBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }

        public long? ProviderId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServicePointDto);
        }

        public bool Equals(ServicePointDto other)
        {

            return other != null &&
                    Id == other.Id &&
                    Location == other.Location &&
                    ServicePointState == other.ServicePointState &&
                    ProviderId == other.ProviderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Location, ServicePointState, ProviderId);
        }
    }
}