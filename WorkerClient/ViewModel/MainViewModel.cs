using AutoMapper;
using ElectronicQueue.ClientInfrastructure;
using ElectronicQueue.ClientInfrastructure.Commands;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WorkerClient;

namespace ElectronicQueue.WorkerClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public bool CanStartServiced { get => canStartServiced; set => Set(ref canStartServiced, value); }// => State == ServicePointState.Closed 
        //                             || State == ServicePointState.Paused;
        public bool CanStopServiced { get => canStopServiced; set => Set(ref canStopServiced, value); }//=> State == ServicePointState.Free
        //                            || State == ServicePointState.Paused;
        public bool CanPausedServiced { get => canPausedServiced; set => Set(ref canPausedServiced, value); }// => State == ServicePointState.Free;

        public ICommand RefreshDataCommand { get; }
        public ICommand AuthorizeCommand { get; }
        public ICommand DeauthorizeCommand { get; }
        public ICommand StartServicedCommand { get; }
        public ICommand PausedServicedCommand { get; }
        public ICommand StopServicedCommand { get; }

        private QueueStateViewModel _page;
        private IMapper _mapper;
        private ObservableCollection<ServiceProviderModel> _providers;
        private ObservableCollection<ServicePointModel> _servicePoints;
        private ServiceProviderModel _selectedProvider;
        private ServicePointModel _selectedServicePoint;
        private WorkerModel _worker;
        private ServicePointState _state;
        private bool canStartServiced;
        private bool canStopServiced;
        private bool canPausedServiced;

        public ObservableCollection<ServiceProviderModel> Providers
        {
            get => _providers;
            set => Set(ref _providers, value);
        }
        public ObservableCollection<ServicePointModel> ServicePoints
        {
            get => _servicePoints;
            set => Set(ref _servicePoints, value);
        }
        public ServiceProviderModel SelectedProvider
        {
            get => _selectedProvider;
            set
            {
                Set(ref _selectedProvider, value);
                if (Page != null && value != null)
                {
                    Page.ServiceProviderId = value.Id;
                }
            }
        }
        public ServicePointModel SelectedServicePoint
        {
            get => _selectedServicePoint;
            set => Set(ref _selectedServicePoint, value);
        }
        public WorkerModel Worker
        {
            get => _worker;
            set => Set(ref _worker, value);
        }
        public ServicePointState State
        {
            get => _state;
            set
            {
                Set(ref _state, value);
                RecalculateFlags();
            }
        }

        public QueueStateViewModel Page
        {
            get => _page;
            set => Set(ref _page, value);
        }

        public MainViewModel()
        {
            Providers = new ObservableCollection<ServiceProviderModel>();
            ServicePoints = new ObservableCollection<ServicePointModel>();
            Page = new QueueStateViewModel();
            State = ServicePointState.Closed;

            RefreshDataCommand = new NonparameterizedCommand(RefreshData);
            StartServicedCommand = new NonparameterizedCommand(x => PointStateChange(ServicePointState.Free));
            PausedServicedCommand = new NonparameterizedCommand(x => PointStateChange(ServicePointState.Paused));
            StopServicedCommand = new NonparameterizedCommand(x => PointStateChange(ServicePointState.Closed));
            AuthorizeCommand = new NonparameterizedCommand(Authorize);
            DeauthorizeCommand = new NonparameterizedCommand(Deauthorize);

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
                Page.Refresh();
                ClearData();
                EndpoinCollection.ServicePoint.Get()
                                              .Select(x => _mapper.Map<ServicePointModel>(x))
                                              .ToList()
                                              .ForEach(x => ServicePoints.Add(x));

                EndpoinCollection.ServicesProvider.Get()
                                              .Select(x => _mapper.Map<ServiceProviderModel>(x))
                                              .ToList()
                                              .ForEach(x => Providers.Add(x));
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

        private void PointStateChange(ServicePointState state)
        {
            try
            {
                if (state == State)
                {
                    return;
                }
                if (SelectedProvider is null)
                {
                    throw new Exception("Выберите сервис");
                }
                if (SelectedServicePoint is null)
                {
                    throw new Exception("Выберите точку обслуживания");
                }
                if (Worker is null)
                {
                    throw new Exception("Необходимо авторизоваться");
                }

                EndpoinCollection.ServicePoint.PointStateChange(new PointStateChangeDto()
                {
                    ServicePointState = state,
                    ProviderId = SelectedProvider.Id,
                    ServicePointId = SelectedServicePoint.Id,
                    WorkerId = Worker.Id
                });
                State = state;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void Authorize()
        {
            try
            {
                bool IsSuccessfull = false;
                WorkerModel worker = null;
                var dialog = new AutorizationWindow(x => { worker = _mapper.Map<WorkerModel>(x); IsSuccessfull = true; });
                dialog.ShowDialog();
                if (IsSuccessfull)
                {
                    Worker = worker;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void Deauthorize()
        {
            try
            {
                //EndpoinCollection.Worker.Deauthorize(Worker.Id);
                Worker = null;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        private void RecalculateFlags()
        {
            CanStartServiced = State == ServicePointState.Closed || State == ServicePointState.Paused;
            CanStopServiced = State == ServicePointState.Free || State == ServicePointState.Paused;
            CanPausedServiced = State == ServicePointState.Free;
        }
    }
}
