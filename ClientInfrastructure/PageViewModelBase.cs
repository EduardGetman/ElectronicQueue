using ElectronicQueue.ClientInfrastructure.Commands;
using ElectronicQueue.ClientInfrastructure.Interface;
using System;
using System.Windows.Input;

namespace ElectronicQueue.ClientInfrastructure
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
        protected virtual void SaveData() => throw new NotImplementedException();
    }
}
