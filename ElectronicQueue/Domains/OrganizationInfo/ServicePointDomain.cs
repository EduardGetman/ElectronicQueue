﻿using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfoDomain;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Domains.OrganizationInfo
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDomain : DomainBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }

        public long? ProviderId { get; set; }
        public ServiceProviderDomain Provider { get; set; }
        public ICollection<WorkerDomain> Workers { get; set; }
    }
}