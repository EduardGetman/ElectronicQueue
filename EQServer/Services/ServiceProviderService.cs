using ElectronicQueue.Data.Domain;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Dto.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    internal class ServiceProviderService : DataServiceBase
    {
        public IEnumerable<ServiceProviderDto> GetAll()
        {
            using EqDbContext context = ContextFactory.CreateContext();
            return context.ServiceProviders.Select(x => new ServiceProviderDto(x));
        }
        public IEnumerable<ServiceProviderDto> GetAllWithServices()
        {
            using EqDbContext context = new EqDbContext();
            return context.ServiceProviders.Include(x => x.Services)
                .Select(x => new ServiceProviderDto(x)
                { Services = x.Services.Select(x => new ServiceDto(x)) }).ToList();
        }
        public void Add(ServiceProviderDto serviceProvider)
        {
            using EqDbContext context = ContextFactory.CreateContext();
            Validation(serviceProvider);

            var oldServiceProvider = context.ServiceProviders.Add(serviceProvider.ToDomain());

            context.SaveChanges();
        }
        public void Update(ServiceProviderDto serviceProvider)
        {
            using EqDbContext context = ContextFactory.CreateContext();
            Validation(serviceProvider);

            var oldServiceProvider = context.ServiceProviders.First(s => s.Id == serviceProvider.Id);
            CopyToOldServiceProvider(serviceProvider, oldServiceProvider);

            context.SaveChanges();
        }
        private static void CopyToOldServiceProvider(ServiceProviderDto serviceProvider, ServiceProviderDomain OldServiceProvider)
        {
            serviceProvider.Name = OldServiceProvider.Name;
        }
    }
}