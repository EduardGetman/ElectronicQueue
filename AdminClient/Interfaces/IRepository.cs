using ElectronicQueue.Core.Application.Model;
using System.Collections.Generic;

namespace ElectronicQueue.AdminClient.Interfaces
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        ICollection<TModel> Data { get; }
        public void Refresh();
        public void Save(IEnumerable<TModel> models);
    }
}
