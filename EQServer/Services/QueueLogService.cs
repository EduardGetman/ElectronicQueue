using System;

namespace ElectronicQueue.EQServer.Services
{
    internal class QueueLogService
    {
        public QueueLogService()
        {

        }
        public void PullTicketEventHandler(long ServiceId, bool IsSpecial)
        {
            throw new NotImplementedException();
        }
        public void PushTicketEventHandler(long ServiceId, bool IsSpecial)
        {
            throw new NotImplementedException();
        }
        public void StopQueueEventHandler(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }
        public void StartQueueEventHandler(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }
    }
}
