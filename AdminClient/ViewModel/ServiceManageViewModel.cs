using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using ElectronicQueue.RestEndpoint.Endpoints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public class ServiceManageViewModel : BaseViewModel
    {
        private ObservableCollection<ServiceProviderModel> _serviceProviders;
        private ServiceProviderModel _selectedServiceProvider;

        private IEnumerable<ServiceProviderModel> _toAdd;

        public ServiceManageViewModel()
        {
            SelectedServiceProvider = new ServiceProviderModel();
        }

        public ServiceProviderModel SelectedServiceProvider
        {
            get => _selectedServiceProvider;
            set
            {
                _selectedServiceProvider = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ServiceProviderModel> ServiceProviders
        {
            get => _serviceProviders;
            set
            {
                _serviceProviders = value;
                OnPropertyChanged();
            }
        }

        protected override void ClearData()
        {
            ServiceProviders.Clear();
            SelectedServiceProvider = default;            
        }

        protected override void LoadData()
        {
            try
            {
                EndpoinCollection.ServicesProvider.GetAllServiceProviders()
                                                  .Where(x => x != null)
                                                  .ToList()
                                                  .ForEach(x => ServiceProviders.Add(x.ToModel()));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        protected override void SaveData()
        {
            
        }
    }
}
