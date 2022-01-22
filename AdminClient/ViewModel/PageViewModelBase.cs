using ElectronicQueue.AdminClient.Commands;
using ElectronicQueue.AdminClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            ClearDataSource();
            LoadData();
            RefreshDataSource();
        }
        protected abstract void ClearDataSource();
        protected abstract void LoadData();
        protected abstract void SaveData();
        protected abstract void RefreshDataSource();
    }
}
