using ElectronicQueue.Data.Domain.Domains.Queue;

namespace ElectronicQueue.EQServer.Services
{
    internal class WorkerService
    {
        public void StartWork(long WorkerId, bool ServiceProviderId, long ServicePointId)
        {
        }
        public void StopWork(long WorkerId)
        {
        }
        public TicketDomain CallClient(long WorkerId)
        {
            return null;
        }
        public void StopWating(long WorkerId)
        {
        }
        public void BeginServiced(long WorkerId)
        {
        }
        public void EndServiced(long WorkerId)
        {
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