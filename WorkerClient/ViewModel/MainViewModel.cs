using AutoMapper;
using ElectronicQueue.ClientInfrastructure;
using ElectronicQueue.ClientInfrastructure.Commands;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ElectronicQueue.Core.Application.Mapping;

namespace ElectronicQueue.WorkerClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand RefreshOnlyPageDataCommand { get; }
        public ICommand RefreshDataCommand { get; }
        //Атворизация
        public ICommand AuthorizeCommand { get; }
        public ICommand DeauthorizeCommand { get; }
        // Состояния точки обслуживания
        public ICommand StartServicedCommand { get; }
        public ICommand PausedServicedCommand { get; }
        public ICommand StopServicedCommand { get; }
        // Статус клиента
        public ICommand CallClientCommand { get; }
        public ICommand DropClientCommand { get; }
        public ICommand BeginServicedClientCommand { get; }
        public ICommand EndServicedClientCommand { get; }


        private ServicePointStateSwithcer _stateSwithcer;

        private QueueStateViewModel _page;
        private IMapper _mapper;
        private ObservableCollection<ServiceProviderModel> _providers;
        private ObservableCollection<ServicePointModel> _servicePoints;
        private ServiceProviderModel _selectedProvider;
        private ServicePointModel _selectedServicePoint;
        private WorkerModel _worker;
        private TicketModel curentTicket;

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

        public QueueStateViewModel Page
        {
            get => _page;
            set => Set(ref _page, value);
        }
        public ServicePointState State
        {
            get => _stateSwithcer.State;
            set => Set(ref _stateSwithcer.State, value);
        }
        public TicketModel CurentTicket 
        {
            get => curentTicket;
            set => Set(ref curentTicket, value);
        }

        public MainViewModel()
        {
            Providers = new ObservableCollection<ServiceProviderModel>();
            ServicePoints = new ObservableCollection<ServicePointModel>();
            Page = new QueueStateViewModel();
            _stateSwithcer = new ServicePointStateSwithcer(ServicePointState.Closed);

            RefreshOnlyPageDataCommand = new NonparameterizedCommand(x=> RefreshData(true));
            RefreshDataCommand = new NonparameterizedCommand(x => RefreshData(false));

            StartServicedCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Free), x => State is ServicePointState.Closed || State is ServicePointState.Paused);
            PausedServicedCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Paused), x => State is ServicePointState.Free);
            StopServicedCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Closed), x => State is ServicePointState.Free || State is ServicePointState.Paused);
            CallClientCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.WaitNext), x => State is (ServicePointState.Free));
            DropClientCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Free), x => State is ServicePointState.WaitNext);
            BeginServicedClientCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Servicing), x => State is ServicePointState.WaitNext);
            EndServicedClientCommand = new RelayCommand<object>(x => PointStateChange(ServicePointState.Free), x => State is ServicePointState.Servicing);

            AuthorizeCommand = new NonparameterizedCommand(Authorize);
            DeauthorizeCommand = new NonparameterizedCommand(Deauthorize);

            _mapper = DtoMapperConfiguration.CreateMapper();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }
        private void RefreshData(bool isOnlyPage = false)
        {
            try
            {
                //if (SelectedProvider)
                //{

                //}
                //Page.ServiceProviderId = SelectedProvider.Id;
                Page.Refresh();
                if (isOnlyPage)
                {
                    return;
                }
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
                if (state == ServicePointState.Closed
                 || (state == ServicePointState.Free && (State == ServicePointState.Closed || State == ServicePointState.Paused))
                 || state == ServicePointState.Paused)
                {
                    EndpoinCollection.ServicePoint.PointStateChange(new PointStateChangeDto()
                    {
                        ServicePointState = state,
                        ProviderId = SelectedProvider.Id,
                        ServicePointId = SelectedServicePoint.Id,
                        WorkerId = Worker.Id
                    });
                }
                if (state == ServicePointState.WaitNext
                 || (state == ServicePointState.Free && (State == ServicePointState.WaitNext || State == ServicePointState.Servicing))
                 || state == ServicePointState.Servicing)
                {
                    var tiket = EndpoinCollection.Queue.SwitchTicketStatus(new SwitchTicketStatusDto()
                    {
                        NewState = state == ServicePointState.WaitNext ? TicketState.Called :
                                   state == ServicePointState.Free && State == ServicePointState.WaitNext ? TicketState.NotServiced :
                                   state == ServicePointState.Free && State == ServicePointState.Servicing ? TicketState.Serviced : TicketState.Servicing,
                        ProviderId = SelectedProvider.Id,
                        ServicePointId = SelectedServicePoint.Id
                    });
                    CurentTicket = _mapper.Map<TicketModel>(tiket);
                }

                State = state;
                RefreshData(true);
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
    }

    public class ServicePointStateSwithcer
    {
        public ServicePointState State;
        public ServicePointStateSwithcer(ServicePointState state)
        {
            State = state;
        }
        public IEnumerable<ServicePointState> NextStates => State switch
        {
            ServicePointState.Closed => new[] { ServicePointState.Free },
            ServicePointState.Free => new[] { ServicePointState.Closed, ServicePointState.Paused, ServicePointState.WaitNext },
            ServicePointState.Paused => new[] { ServicePointState.Free, ServicePointState.Closed },
            ServicePointState.Servicing => new[] { ServicePointState.Free },
            ServicePointState.WaitNext => new[] { ServicePointState.Servicing, ServicePointState.Free },
            _ => Enumerable.Empty<ServicePointState>(),
        };
        public bool CanChangeState(ServicePointState newState) => NextStates.Contains(newState);
        public bool StateEqual(params ServicePointState[] oldState) => oldState.Contains(State);
    }
}
