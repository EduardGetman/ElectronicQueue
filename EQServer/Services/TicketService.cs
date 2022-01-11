using ElectronicQueue.Data.Domain;
using ElectronicQueue.Data.Domain.Domains.QueueDomain;
using ElectronicQueue.Data.Dto.Entitys;
using ElectronicQueue.Data.Enums;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    class TicketService : DataServiceBase
    {
        public TicketDomain GetByQueueId(ulong queueId)
        {
            //using EqDbContext context = ContextFactory.CreateContext();
            //return context.Tickets.FirstOrDefault(x => x.QueueId == queueId);
            throw new System.Exception();
        }
        public void Update(TicketDto queue)
        {
            using EqDbContext context = ContextFactory.CreateContext();
            Validation(queue);

            var oldQueue = context.Queues.First(q => q.Id == queue.Id);

            context.SaveChanges();
        }
        public void UpdateState(TicketState ticketState, long id)
        {
            using EqDbContext context = ContextFactory.CreateContext();

            var ticket = context.Tickets.First(q => q.Id == id);
            ticket.State = ticketState;

            context.SaveChanges();
        }
    }
}