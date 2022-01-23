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
        protected void ClearDataSource()
        {
            DataSource.Clear();
            SelectedProvider = default;
        }
        protected void LoadData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        protected override void SaveData()
        {

        }

        protected override void RefreshData()
        {
            throw new NotImplementedException();
        }
    }
}
