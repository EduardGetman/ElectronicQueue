using ElectronicQueue.Data;
using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Dto;
using ElectronicQueue.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    class TicketService : DataServiceBase
    {
        public TicketDomain GetByQueueId(ulong queueId)
        {
            using Context context = DBContextFactory.CreateDbContext();
            return context.Tickets.FirstOrDefault(x => x.QueueId == queueId);
        }
        public void Update(TicketDto queue)
        {
            using Context context = DBContextFactory.CreateDbContext();
            Validation(queue);

            var oldQueue = context.Queues.First(q => q.Id == queue.Id);

            context.SaveChanges();
        }
        public void UpdateState(TicketState ticketState, ulong id)
        {
            using Context context = DBContextFactory.CreateDbContext();

            var ticket = context.Tickets.First(q => q.Id == id);
            ticket.State = ticketState;

            context.SaveChanges();
        }
    }
}