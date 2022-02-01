using ElectronicQueue.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.AdminClient.Interfaces
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        ICollection<TModel> Data { get; }
        public void Refresh();
        public void Save(IEnumerable<TModel> models);
    }
}
