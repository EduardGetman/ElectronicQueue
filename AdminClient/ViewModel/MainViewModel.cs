using ElectronicQueue.AdminClient.Infrastructure.Commands;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.AdminClient.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ChangePageCommand { get; }

        private readonly Dictionary<Type, Lazy<IPage>> _pages;
        private IPage _page;

        public IPage Page
        {
            get => _page;
            set => Set(ref _page, value);
        }


        public MainViewModel()
        {
            _pages = new Dictionary<Type, Lazy<IPage>>();

            AddPage(typeof(ServiceManageViewModel));
            AddPage(typeof(ServicePointViewModel));
            AddPage(typeof(QueueViewModel));
            AddPage(typeof(ServiceStatisticView));
            AddPage(typeof(WorkerStatisticViewModel));

            ChangePageCommandExecuted(typeof(ServiceManageViewModel));


            ChangePageCommand = new RelayCommand<object>(ChangePageCommandExecuted, ChangePageCommandCanExecuted);
        }

        private void AddPage(Type type)
        {
            if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IPage)))
            {
                _pages[type] = new Lazy<IPage>((IPage)type.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>()));
            }
        }

        private void ChangePageCommandExecuted(object type) => Page = _pages[type as Type].Value;

        private bool ChangePageCommandCanExecuted(object type)
            => (type as Type).GetTypeInfo().ImplementedInterfaces.Contains(typeof(IPage)) && _pages.ContainsKey(type as Type);


    }
}
