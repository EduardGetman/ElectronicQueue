using ElectronicQueue.AdminClient.Infrastructure.Commands;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Core.Application.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public abstract class PageViewModelBase : ViewModelBase, IPage
    {
        public ICommand RefreshDataCommand { get; }
        public ICommand SaveDataCommand { get; }
        public abstract string Title { get; }

        public PageViewModelBase()
        {
            RefreshDataCommand = new NonparameterizedCommand(RefreshData);
            SaveDataCommand = new NonparameterizedCommand(SaveData);
        }

        protected abstract void RefreshData();
        protected abstract void SaveData();
    }
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
