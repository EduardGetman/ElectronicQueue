using ElectronicQueue.Data.MockModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ElectronicQueue.AdminClient.View
{
    /// <summary>
    /// Логика взаимодействия для ServicePointView.xaml
    /// </summary>
    public partial class ServicePointView : UserControl
    {
        public ServicePointView()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = new List<ServicePointModel>
            { 
                new ServicePointModel() { Location = "Кабинет #1", Provider = "Терапевт", ProviderId = 1, ServicePointState = "Ожидает клиента" },
                new ServicePointModel() { Location = "Кабинет #2", Provider = "Терапевт", ProviderId = 1, ServicePointState = "Обслуживает клиента" },
                new ServicePointModel() { Location = "Кабинет #3", Provider = "Лор", ProviderId = 1, ServicePointState = "Обслуживает клиента" },
                new ServicePointModel() { Location = "Кабинет #4", Provider = "Педиатор", ProviderId = 1, ServicePointState = "Не работает" },
            };
        }
    }
}
