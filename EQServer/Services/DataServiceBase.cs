using ElectronicQueue.Data.Domain;
using ElectronicQueue.Data.Domain.Domains;
using System.ComponentModel.DataAnnotations;

namespace ElectronicQueue.EQServer.Services
{
    internal class DataServiceBase
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