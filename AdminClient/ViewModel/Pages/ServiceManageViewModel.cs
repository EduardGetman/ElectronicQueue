using ElectronicQueue.AdminClient.Infrastructure.Repositories;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Core.Application.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class ServiceManageViewModel : DataEditPageViewModelBase<ServiceProviderModel>
    {
        public override string Title => "Сервисы и услуги";

        private IRepository<ServiceProviderModel> _servicesRepository;
        private ObservableCollection<ServiceProviderModel> _serviceProviders;
        private ServiceProviderModel _selectedServiceProvider;

        public ServiceProviderModel SelectedProvider
        {
            get => _selectedServiceProvider;
            set
            {
                Set(ref _selectedServiceProvider, value);
            }
        }
        public override ObservableCollection<ServiceProviderModel> DataSource
        {
            get => _serviceProviders;
            set => Set(ref _serviceProviders, value);
        }

        protected override IRepository<ServiceProviderModel> repository => _servicesRepository;

        public ServiceManageViewModel()
        {
            _servicesRepository = new ServicesRepository();
            DataSource = new ObservableCollection<ServiceProviderModel>();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }
        protected override void ClearData()
        {
            try
            {
                SelectedProvider = null;
                base.ClearData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
