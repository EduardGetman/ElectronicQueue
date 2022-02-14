using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using ElectronicQueue.AdminClient.Infrastructure.Repositories;
using ElectronicQueue.AdminClient.Interfaces;

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
