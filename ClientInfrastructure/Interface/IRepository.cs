using ElectronicQueue.Core.Application.Models;
using System.Collections.Generic;

namespace ElectronicQueue.ClientInfrastructure.Interface
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        ICollection<TModel> Data { get; }
        public void Refresh();
        public void Save(IEnumerable<TModel> models);
    }
}
