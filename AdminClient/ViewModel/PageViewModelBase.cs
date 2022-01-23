using ElectronicQueue.AdminClient.Infrastructure.Commands;
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

        protected abstract void RefreshData();
        protected abstract void SaveData();
    }
}
