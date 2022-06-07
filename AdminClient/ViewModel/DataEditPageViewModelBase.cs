using ElectronicQueue.ClientInfrastructure;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.Core.Application.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public abstract class DataEditPageViewModelBase<TModel> : PageViewModelBase where TModel : ModelBase
    {
        public abstract ObservableCollection<TModel> DataSource { get; set; }
        protected abstract IRepository<TModel> repository { get; }
        protected override void SaveData()
        {
            try
            {
                repository.Save(DataSource);
                RefreshData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        protected virtual void ClearData()
        {
            try
            {
                while (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(DataSource[0]);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        protected override void RefreshData()
        {
            try
            {
                ClearData();
                repository?.Refresh();
                repository?.Data.ToList().ForEach(x => DataSource.Add(x));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
