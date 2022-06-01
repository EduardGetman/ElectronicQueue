using ElectronicQueue.AdminClient.Infrastructure.Repositories;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Core.Application.Model;
using ElectronicQueue.Data.Common.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class ServicePointViewModel : DataEditPageViewModelBase<ServicePointModel>
    {
        public override string Title => "Точки обслуживания";

        private IRepository<ServicePointModel> _servicesRepository;
        private ObservableCollection<ServicePointModel> _servicePoints;

        public List<string> States => new List<string>(typeof(ServicePointState).GetEnumNames());

        public override ObservableCollection<ServicePointModel> DataSource
        {
            get => _servicePoints;
            set => Set(ref _servicePoints, value);
        }

        protected override IRepository<ServicePointModel> repository => _servicesRepository;

        public ServicePointViewModel()
        {
            _servicesRepository = new ServicesPointRepository();
            DataSource = new ObservableCollection<ServicePointModel>();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }
    }
}
