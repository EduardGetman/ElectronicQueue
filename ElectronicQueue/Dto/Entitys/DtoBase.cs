using ElectronicQueue.Data.Domains;

namespace ElectronicQueue.Data.Dto.Entitys
{
    public abstract class DtoBase
    {
        public ulong Id { get; set; }
        protected DtoBase()
        {}
        protected DtoBase(DomainBase domain)
        {
            Id = domain.Id;
        }
        protected TDomain ToDomain<TDomain>() where TDomain : DomainBase, new()
        {
            return new TDomain() { Id = Id };
        }
    }
}
