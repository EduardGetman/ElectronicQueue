using AutoMapper;
using ElectronicQueue.ClientInfrastructure;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.ObjectModel;

namespace ElectronicQueue.WorkerClient.ViewModel
{
    public class QueueStateViewModel : PageViewModelBase
    {
        private long _serviceProviderId;
        private IMapper _mapper = DtoMapperConfiguration.CreateMapper();
        private QueueModel _queue;
        private ObservableCollection<TicketModel> _tickets;
        public override string Title => "Состояние очереди";

        public QueueModel Queue
        {
            get => _queue;
            set => Set(ref _queue, value);
        }
        public ObservableCollection<TicketModel> DataSource
        {
            get => _tickets;
            set => Set(ref _tickets, value);
        }
        public long ServiceProviderId
        {
            get => _serviceProviderId;
            set
            {
                Set(ref _serviceProviderId, value);
                if (_serviceProviderId != 0)
                {
                    RefreshData();
                }
            }

        }

        private void ClearData()
        {
            try
            {
                while (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(DataSource[0]);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        public void Refresh() => RefreshData();
        protected override void RefreshData()
        {
            try
            {
                if (ServiceProviderId != 0)
                {
                    ClearData();
                    Queue = _mapper.Map<QueueModel>(EndpoinCollection.Queue.GetByProviderId(ServiceProviderId));
                    DataSource = Queue.Tikets;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

    }
}
