using ElectronicQueue.Core.Domain;
using System.Collections.Generic;

namespace ElectronicQueue.EQServer.Interfaces
{
    public interface IQueueServices
    {
        public QueueDomain CreateQueue(List<string> existedLetters);
        public void StopQueue(long ServiceProviderId);

        public void StartQueue(long ServiceProviderId);

        public TicketDomain Pull(long ServiceProviderId);

        public TicketDomain Peek(long ServiceProviderId);

        public void Push(long ServiceProviderId, TicketDomain ticket);
    }
}
