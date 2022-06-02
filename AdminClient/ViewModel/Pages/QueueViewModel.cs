using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.ClientInfrastructure.Repositories;
using ElectronicQueue.Core.Application.Models;
using System;
using System.Collections.ObjectModel;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class QueueViewModel : DataEditPageViewModelBase<QueueModel>
    {
        public override string Title => "Состояние очередей";

        private IRepository<QueueModel> _queueRepository;
        private ObservableCollection<QueueModel> _queues;
        private QueueModel _selectedQueue;

        public QueueModel SelectedQueue
        {
            get => _selectedQueue;
            set => Set(ref _selectedQueue, value);
        }
        public override ObservableCollection<QueueModel> DataSource
        {
            get => _queues;
            set => Set(ref _queues, value);
        }

        protected override IRepository<QueueModel> repository => _queueRepository;

        public QueueViewModel()
        {
            _queueRepository = new QueueRepository();
            DataSource = new ObservableCollection<QueueModel>();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }
        protected override void ClearData()
        {
            try
            {
                SelectedQueue = null;
                base.ClearData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
