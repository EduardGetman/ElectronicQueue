using ElectronicQueue.Data;
using ElectronicQueue.Data.Domains;
using System.ComponentModel.DataAnnotations;

namespace ElectronicQueue.EQServer.Services
{
    class DataServiceBase
    {
        protected void Validation<T>(T domain)
        {
            if (domain is null)
            {
                throw new ValidationException("Передан пустой объект");
            }
        }
        public void Add<TDomain>(TDomain domain) where TDomain : DomainBase
        {
            using EqDbContext context = ContextFactory.CreateContext();
            Validation(domain);

            context.Add(domain);
            context.SaveChanges();
        }
    }
}