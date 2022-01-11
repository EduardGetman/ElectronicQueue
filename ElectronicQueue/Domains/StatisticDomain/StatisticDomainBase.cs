using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Data.Domain.Domains.StatisticDomain
{
    public abstract class StatisticDomainBase : DomainBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StatisticKind Kind { get; set; }
    }
}