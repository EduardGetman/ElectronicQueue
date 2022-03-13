using ElectronicQueue.Data.MockModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ElectronicQueue.AdminClient.View
{
    /// <summary>
    /// Логика взаимодействия для ServiceManageView.xaml
    /// </summary>
    public partial class ServiceManageView : UserControl
    {
        public ServiceManageView()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = new List<ServiceProviderModel>
            {
                new ServiceProviderModel() { Name="Терапевт", Queue = "A", IsProvided = true, ServicesCount = "4"},
                new ServiceProviderModel() { Name="Лор", Queue = "B", IsProvided = true, ServicesCount = "5"},
                new ServiceProviderModel() { Name="Педиатор", Queue = "C", IsProvided = false, ServicesCount = "3"},
            };
            DataGrid2.ItemsSource = new List<ServiceModel>
            {
                new ServiceModel() { Name="Первичный осмотр", IsProvided = true},
                new ServiceModel() { Name="Консультация", IsProvided = false},
                new ServiceModel() { Name="Открытие больничего", IsProvided = true},
                new ServiceModel() { Name="Закрытие больничего", IsProvided = true},
            };
        }
    }
}
