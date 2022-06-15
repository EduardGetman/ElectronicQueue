using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Window> Windows { get; set; }
        public ServiceProviderDto SelectedServiceProvider { get=>  ProviderComboBox.SelectedItem as ServiceProviderDto; set => ProviderComboBox.SelectedItem = value; }
        public List<ServiceProviderDto> Providers { get => ProviderComboBox.ItemsSource.Cast<ServiceProviderDto>().ToList(); set => ProviderComboBox.ItemsSource = value; }
        public MainWindow()
        {
            InitializeComponent();
            Windows = new List<Window>();
        }
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            if (SelectedServiceProvider == null)
            {
                return;
            }
            var queueStateWindow = new QueueStateWindow1(SelectedServiceProvider.Id);
            queueStateWindow.Show();
            Windows.Add(queueStateWindow);
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SelectedServiceProvider = null;
            Providers = EndpoinCollection.ServicesProvider.Get().ToList();
        }
    }
}
