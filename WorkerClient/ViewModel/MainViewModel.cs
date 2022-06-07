using AutoMapper;
using ElectronicQueue.ClientInfrastructure;
using ElectronicQueue.ClientInfrastructure.Commands;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ElectronicQueue.WorkerClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand RefreshDataCommand { get; }
        private IPage _page;
        private IMapper _mapper;
        private ObservableCollection<ServiceProviderModel> _providers;
        private ObservableCollection<ServicePointModel> _servicePoints;
        private ServiceProviderModel _selectedProvider;
        private ServicePointModel _selectedServicePoint;

        public ObservableCollection<ServiceProviderModel> Providers { get => _providers; set => Set(ref _providers, value); }
        public ObservableCollection<ServicePointModel> ServicePoints { get => _servicePoints; set => Set(ref _servicePoints, value); }
        public ServiceProviderModel SelectedProvider { get => _selectedProvider; set => Set(ref _selectedProvider, value); }
        public ServicePointModel SelectedServicePoint { get => _selectedServicePoint; set => Set(ref _selectedServicePoint, value); }

        public IPage Page
        {
            get => _page;
            set => Set(ref _page, value);
        }

        public MainViewModel()
        {
            Providers = new ObservableCollection<ServiceProviderModel>();
            ServicePoints = new ObservableCollection<ServicePointModel>();
            Page = new QueueStateViewModel(51);
            RefreshDataCommand = new NonparameterizedCommand(RefreshData);
            _mapper = DtoMapperConfiguration.CreateMapper();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }
        private void RefreshData()
        {
            try
            {
                ClearData();
                EndpoinCollection.ServicePoint.Get()
                                              .Select(x => _mapper.Map<ServicePointModel>(x))
                                              .ToList()
                                              .ForEach(x => ServicePoints.Add(x));

                EndpoinCollection.ServicesProvider.Get()
                                              .Select(x => _mapper.Map<ServiceProviderModel>(x))
                                              .ToList()
                                              .ForEach(x => Providers.Add(x));
                SelectedProvider = Providers.FirstOrDefault();
                SelectedServicePoint = ServicePoints.FirstOrDefault();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        private void ClearData()
        {
            try
            {
                while (Providers != null && Providers.Count > 0)
                {
                    Providers.Remove(Providers[0]);
                }
                while (ServicePoints != null && ServicePoints.Count > 0)
                {
                    ServicePoints.Remove(ServicePoints[0]);
                }
                SelectedProvider = default;
                SelectedServicePoint = default;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
