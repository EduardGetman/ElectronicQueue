using System;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Очередь в обслуживающий сервис
    /// </summary>
    public class QueueDto : DtoBase
    {
        public int NextTicketNumber { get; set; }
        public string Letters { get; set; }
        public bool IsEnabled { get; set; }
        public long ProviderId { get; set; }
        public ServiceProviderDto Provider { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as QueueDto);
        }

        public bool Equals(QueueDto other)
        {
            return other != null &&
                   Id == other.Id &&
                   NextTicketNumber == other.NextTicketNumber &&
                   Letters == other.Letters &&
                   IsEnabled == other.IsEnabled &&
                   ProviderId == other.ProviderId &&
                   (Provider?.Equals(other.Provider) ?? other is null);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NextTicketNumber, Letters, IsEnabled, ProviderId, Provider);
        }
    }
}
