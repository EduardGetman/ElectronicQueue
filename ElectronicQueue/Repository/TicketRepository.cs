using ElectronicQueue.Data.Domain.Domains.Queue;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Repository
{
    public class TicketRepository
    {
        public IEnumerable<TicketDomain> Get()
        {
            throw new NotImplementedException();
        }

        public TicketDomain Get(long id)
        {
            throw new NotImplementedException();
        }
        public void Post(TicketDomain domain)
        {
        }
        public void Put(TicketDomain domain)
        {
        }
        public void Delete(long id)
        {
        }
    }
}
