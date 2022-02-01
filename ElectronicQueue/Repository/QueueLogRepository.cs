using ElectronicQueue.Data.Domain.Domains.LogDomain;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Repository
{
    public class QueueLogRepository
    {
        public IEnumerable<QueueLogDomain> Get()
        {
            throw new NotImplementedException();
        }

        public QueueLogDomain Get(long id)
        {
            throw new NotImplementedException();
        }
        public void Post(QueueLogDomain domain)
        {
        }
        public void Put(QueueLogDomain domain)
        {
        }
        public void Delete(long id)
        {
        }
    }
}
