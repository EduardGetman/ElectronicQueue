using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;
using System.Collections.Generic;

namespace ElectronicQueue.EQServer.Interfaces
{
    public interface IQueueServices
    {
        void UpdateQueues(IEnumerable<QueueDto> queues);
        QueueDomain CreateQueue(List<string> existedLetters);
        TicketDomain Pull(long serviceProviderId);
        TicketDomain Push(TicketCreateDto createDto);
        TicketDomain SwitchTicketStatus(SwitchTicketStatusDto dto);
    }
}
