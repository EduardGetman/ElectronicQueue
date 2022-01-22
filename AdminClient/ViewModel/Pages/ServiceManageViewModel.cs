using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class ServiceManageViewModel : PageViewModelBase
    {

        public override string Title => "Сервисы и услуги";

        private List<ServiceProviderDto> _loadedData;

        private ObservableCollection<ServiceProviderModel> _serviceProviders;
        private ServiceProviderModel _selectedServiceProvider;
        public ServiceManageViewModel()
        {
            SelectedProvider = new ServiceProviderModel();
        }

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
        protected override void ClearDataSource()
        {
            DataSource.Clear();
            SelectedProvider = default;
        }
        protected override void LoadData()
        {
            try
            {
                _loadedData = EndpoinCollection.ServicesProvider.GetAllServiceProviders()
                                                                .Where(x => x != null)
                                                                .ToList();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        protected override void SaveData()
        {

        }
        protected override void RefreshDataSource()
        {
        }
    }
}
