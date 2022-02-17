using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Core.Domain
{
    public abstract class StatisticDomainBase : DomainBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StatisticKind Kind { get; set; }
    }
}