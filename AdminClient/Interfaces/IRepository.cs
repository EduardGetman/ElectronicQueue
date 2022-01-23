using ElectronicQueue.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.AdminClient.Interfaces
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        public ICollection<TModel> GetCollection();
        public bool Refresh();
        public void Save();
    }
}
