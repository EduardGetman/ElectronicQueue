using ElectronicQueue.Data.Common.Enums;
using System;

namespace ElectronicQueue.Data.Dto.Entitys.Statistic
{
    public abstract class StatisticDtoBase : DtoBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StatisticKind Kind { get; set; }
    }
}