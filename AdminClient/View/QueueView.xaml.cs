using ElectronicQueue.Data.MockModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ElectronicQueue.AdminClient.View
{
    /// <summary>
    /// Логика взаимодействия для QueueView.xaml
    /// </summary>
    public partial class QueueView : UserControl
    {
        public QueueView()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = new List<QueueModel>
            {
                new QueueModel() { Name="Терапевт", Letters = "A", IsProvided = true, ServicesCount = "5"},
                new QueueModel() { Name="Лор", Letters = "B", IsProvided = true, ServicesCount = "7"},
                new QueueModel() { Name="Педиатор", Letters = "C", IsProvided = false, ServicesCount = "0"},
            };
            DataGrid2.ItemsSource = new List<TicketModel>
            {
                new TicketModel() { State="Обслуживается", Name = "Первичный осмотр", Type = "Специальный", isProvided = true},
                new TicketModel() { State="Ожидает", Name = "Первичный осмотр", Type = "Обычный", isProvided = false},
                new TicketModel() { State="Ожидает", Name = "Закрытие больниченого", Type = "Обычный", isProvided = false},
                new TicketModel() { State="Ожидает", Name = "Открытие больниченого", Type = "Обычный", isProvided = false},
                new TicketModel() { State="Ожидает", Name = "Первичный осмотр", Type = "Обычный", isProvided = false},
            };
        }
    }
}
