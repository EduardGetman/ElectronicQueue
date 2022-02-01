using ElectronicQueue.Data.Domain.Domains.LogDomain;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Repository
{
    public class WorkerLogRepository
    {
        public IEnumerable<WorkerLogDomain> Get()
        {
            throw new NotImplementedException();
        }

        public WorkerLogDomain Get(long id)
        {
            throw new NotImplementedException();
        }
        public void Post(WorkerLogDomain domain)
        {
        }
        public void Put(WorkerLogDomain domain)
        {
        }
        public void Delete(long id)
        {
        }
    }
}
