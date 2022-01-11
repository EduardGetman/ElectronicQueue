using ElectronicQueue.Data.Enums;
using System;

namespace ElectronicQueue.Data.Domains.StatisticDomain
{
    public abstract class StatisticDomainBase: DomainBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StatisticKind Kind { get; set; }
    }
}