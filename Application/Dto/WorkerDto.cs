using System;
using System.Collections.Generic;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Работник
    /// </summary>
    public class WorkerDto : DtoBase
    {
        public string Name { get; set; }
        public long AccountId { get; set; }
        public long? PointId { get; set; }
        public ServicePointDto Point { get; set; }
        public AccountDto Account { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as WorkerDto);
        }

        public bool Equals(WorkerDto other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   AccountId == other.AccountId &&
                   PointId == other.PointId && 
                   (Point?.Equals(other.Point) ?? other.Point is null) &&
                   (Account?.Equals(other.Account) ?? other.Account is null);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, AccountId, PointId, Point, Account);
        }
    }
}
