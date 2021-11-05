using ElectronicQueue.Data.Domains;
using System;

namespace ElectronicQueue.Data.Dto
{
    public abstract class DtoBase
    {
        protected DtoBase(DomainBase domain)
        {
            Id = domain.Id;
        }
        protected TDomain ToDomain<TDomain>() where TDomain : DomainBase, new()
        {
            return new TDomain() { Id = Id };
        }
        public ulong Id { get; set; }
    }
}
