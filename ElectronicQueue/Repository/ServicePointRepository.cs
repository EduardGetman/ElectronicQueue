using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.Data.Domain.Repository
{
    public class ServicePointRepository
    {
        public IEnumerable<ServicePointDomain> Get()
        {
            throw new NotImplementedException();
        }

        public ServicePointDomain Get(long id)
        {
            throw new NotImplementedException();
        }
        public void Post(ServicePointDomain domain)
        {
        }
        public void Put(ServicePointDomain domain)
        {
        }
        public void Delete(long id)
        {
        }
    }
}
