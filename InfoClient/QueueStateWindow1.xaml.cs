using AutoMapper;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InfoClient
{
    /// <summary>
    /// Логика взаимодействия для QueueStateWindow1.xaml
    /// </summary>
    public partial class QueueStateWindow1 : Window
    {
        public QueueStateWindow1(long serviceProviderId)
        {
            InitializeComponent();
            //Timer = new Timer(new TimerCallback(x => RefreshData()), null, 0, 5000);
            _serviceProviderId = serviceProviderId;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(RefreshData);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
            RefreshData(null, null);
        }
        IMapper _mapper = DtoMapperConfiguration.CreateMapper();

        private long _serviceProviderId;

        public QueueModel Queue { get; set; }
        public List<TicketModel> DataSource { get; set; }
        public void RefreshData(object sender, EventArgs e)
        {
            try
            {
                if (_serviceProviderId != 0)
                {
                    Queue = _mapper.Map<QueueModel>(EndpoinCollection.Queue.GetByProviderId(_serviceProviderId));
                    DataSource = Queue.Tikets.ToList();
                    MainDataGrid.ItemsSource = DataSource;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
