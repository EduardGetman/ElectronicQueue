using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Entitys
{
    public abstract class DtoBase
    {
        public ulong Id { get; set; }
        protected DtoBase()
        { }
        protected DtoBase(DomainBase domain)
        {
            Id = domain.Id;
        }
        protected DtoBase(ModelBase model)
        {
            Id = model.Id;
        }
        protected TDomain ToDomain<TDomain>() where TDomain : DomainBase, new()
        {
            return new TDomain() { Id = Id };
        }
        protected TModel ToModel<TModel>() where TModel : ModelBase, new()
        {
            return new TModel() { Id = Id };
        }
    }
}
