using ElectronicQueue.Core.Domain;
using System;

namespace ElectronicQueue.EQServer.Services
{
    internal class QueueService
    {

        public void StopQueue(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public void StartQueue(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public TicketDomain Dequeu(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public TicketDomain Peek(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public void Push(long ServiceProviderId, TicketDomain ticket)
        {
            throw new NotImplementedException();
        }
    }

}