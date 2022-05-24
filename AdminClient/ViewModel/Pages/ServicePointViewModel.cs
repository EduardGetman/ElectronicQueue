using ElectronicQueue.AdminClient.Infrastructure.Repositories;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class ServicePointViewModel : PageViewModelBase
    {
        public override string Title => "Точки обслуживания";

        private IRepository<ServicePointModel> _servicesRepository;
        private ObservableCollection<ServicePointModel> _servicePoints;

        public List<string> States => new List<string>(typeof(ServicePointState).GetEnumNames());

        public ObservableCollection<ServicePointModel> DataSource
        {
            get => _servicePoints;
            set => Set(ref _servicePoints, value);
        }

        public ServicePointViewModel()
        {
            _servicesRepository = new ServicesPointRepository();
            DataSource = new ObservableCollection<ServicePointModel>();
        }

        protected override void SaveData()
        {

        }

        protected override void RefreshData()
        {
            try
            {
                DataSource.Clear();
                _servicesRepository.Data.ToList().ForEach(x => DataSource.Add(x));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
