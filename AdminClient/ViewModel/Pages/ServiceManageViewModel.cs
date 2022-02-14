using ElectronicQueue.AdminClient.Infrastructure.Repositories;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Data.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class ServiceManageViewModel : PageViewModelBase
    {
        public override string Title => "Сервисы и услуги";

        private IRepository<ServiceProviderModel> _servicesRepository;
        private ObservableCollection<ServiceProviderModel> _serviceProviders;
        private ServiceProviderModel _selectedServiceProvider;

        public ServiceProviderModel SelectedProvider
        {
            get => _selectedServiceProvider;
            set => Set(ref _selectedServiceProvider, value);
        }
        public ObservableCollection<ServiceProviderModel> DataSource
        {
            get => _serviceProviders;
            set => Set(ref _serviceProviders, value);
        }

        public ServiceManageViewModel()
        {
            _servicesRepository = new ServicesRepository();
            DataSource = new ObservableCollection<ServiceProviderModel>();
        }

        protected override void SaveData()
        {

        }

        protected override void RefreshData()
        {
            try
            {
                DataSource.Clear();
                SelectedProvider = default;
                _servicesRepository.Data.ToList().ForEach(x => DataSource.Add(x));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
