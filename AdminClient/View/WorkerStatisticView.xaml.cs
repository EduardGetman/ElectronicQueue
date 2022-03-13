using ElectronicQueue.Data.MockModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ElectronicQueue.AdminClient.View
{
    /// <summary>
    /// Логика взаимодействия для WorkerStatisticView.xaml
    /// </summary>
    public partial class WorkerStatisticView : UserControl
    {
        public WorkerStatisticView()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = new List<ServiceStatisticModel>
            {
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "3:42", UnServicedCount = "2", ClientCount = "35", StratPeriod = "01.03.2022 0:00", EndPeriod ="01.03.2022 23:59"},
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "3:46", UnServicedCount = "2", ClientCount = "35", StratPeriod = "02.03.2022 0:00", EndPeriod ="02.03.2022 23:59",},
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "4:12", UnServicedCount = "2", ClientCount = "35", StratPeriod = "03.03.2022 0:00", EndPeriod ="03.03.2022 23:59",},
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "6:12", UnServicedCount = "2", ClientCount = "35", StratPeriod = "04.03.2022 0:00", EndPeriod ="04.03.2022 23:59",},
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "2:22", UnServicedCount = "2", ClientCount = "35", StratPeriod = "05.03.2022 0:00", EndPeriod ="05.03.2022 23:59",},
                new ServiceStatisticModel() { Name = "Иванов Иван Иванович", Continues = "0:0", UnServicedCount = "0", ClientCount = "0", StratPeriod = "06.03.2022 0:00", EndPeriod ="06.03.2022 23:59"},

            };
        }
    }
}
