using ElectronicQueue.Data.Domain;
using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Dto.Entitys.Queue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    internal class QueueService
    {
    //    public QueueDomain GetQueue(long ServiceProviderId)
    //    {
    //        QueueDomain domain = new QueueDomain();
    //        Peek(3);
    //        Dequeu(3);
    //        throw new NotImplementedException();
    //    }

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
    //{
    //internal class QueueService : DataServiceBase
    //{
    //    public IEnumerable<QueueDomain> GetByPrviderId(params long[] ProviderId)
    //    {
    //        using EqDbContext context = ContextFactory.CreateContext();
    //        return context.Queues.Where(x => ProviderId.Any(p => p == x.ProviderId)).ToList();
    //    }
    //    public QueueDomain GetByPrviderId(long ProviderId)
    //    {
    //        using EqDbContext context = ContextFactory.CreateContext();
    //        return context.Queues.FirstOrDefault(x => x.ProviderId == ProviderId);
    //    }

    //    public void Update(QueueDto queue)
    //    {
    //        using EqDbContext context = ContextFactory.CreateContext();
    //        Validation(queue);

    //        var oldQueue = context.Queues.First(q => q.Id == queue.Id);
    //        CopyToOldQueue(queue, oldQueue);

    //        context.SaveChanges();
    //    }
    //    private static void CopyToOldQueue(QueueDto queue, QueueDomain oldQueue)
    //    {
    //        oldQueue.IsEnabled = queue.IsEnabled;
    //        oldQueue.Letters = queue.Letters;
    //        oldQueue.ProviderId = queue.ProviderId;
    //    }
    //}
}