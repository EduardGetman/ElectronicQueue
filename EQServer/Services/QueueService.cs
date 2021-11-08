using ElectronicQueue.Data;
using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    class QueueService : DataServiceBase
    {
        public IEnumerable<QueueDomain> GetByPrviderId(params ulong[] ProviderId)
        {
            using Context context = DBContextFactory.CreateDbContext();
            return context.Queues.Where(x => ProviderId.Any(p => p == x.ProviderId)).ToList();
        }
        public QueueDomain GetByPrviderId(ulong ProviderId)
        {
            using Context context = DBContextFactory.CreateDbContext();
            return context.Queues.FirstOrDefault(x => x.ProviderId == ProviderId);
        }
        //public void Add(QueueDomain queue)
        //{
        //    using Context context = DBContextFactory.CreateDbContext();
        //    Validation(queue);

        //    context.Add(queue);
        //    context.SaveChanges();
        //}

        public void Update(QueueDto queue)
        {
            using Context context = DBContextFactory.CreateDbContext();
            Validation(queue);

            var oldQueue = context.Queues.First(q => q.Id == queue.Id);
            CopyToOldQueue(queue, oldQueue);

            context.SaveChanges();
        }
        private static void CopyToOldQueue(QueueDto queue, QueueDomain oldQueue)
        {
            oldQueue.IsEnabled = queue.IsEnabled;
            oldQueue.Letters = queue.Letters;
            oldQueue.NumberLastTickets = queue.NumberLastTickets;
            oldQueue.ProviderId = queue.ProviderId;
        }
    }
}