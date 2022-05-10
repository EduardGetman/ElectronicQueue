using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.RestEndpoint.Endpoints;
using System.Collections.Generic;
using System.Windows;

namespace ClientTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServicesProviderEndpoint _servicesEndpoint = new ServicesProviderEndpoint();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            var providerDtos = new List<ServiceProviderDto>()
            {
                new ServiceProviderDto()
                {
                    Name = "Терапевт", 
                    Services = new List<ServiceDto>
                    { 
                        new ServiceDto { Name="Первичный осмотр",},
                        new ServiceDto { Name="Консультация", },
                        new ServiceDto {Name="Открытие больничего", },
                        new ServiceDto { Name="Закрытие больничего", }
                    }
                },           
                new ServiceProviderDto()
                {
                    Name = "Лор",
                    Services = new List<ServiceDto>
                    {
                    }
                },
            };
            var terminalWindow = new TermenalWindow(providerDtos);
            terminalWindow.Show();
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
