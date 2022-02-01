using ElectronicQueue.Data.Domain.Domains.Queue;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Repository
{
    public class QueueRepository
    {
        public IEnumerable<QueueDomain> Get()
        {
            throw new NotImplementedException();
        }

        public QueueDomain Get(long id)
        {
            throw new NotImplementedException();
        }
        public void Post( QueueDomain domain)
        {
        }
        public void Put(QueueDomain domain)
        {
        }
        public void Delete(long id)
        {
        }
    }
}
