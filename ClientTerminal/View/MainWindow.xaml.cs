﻿using ElectronicQueue.RestEndpoint.Endpoints;
using System.Windows;

namespace ClientTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ServicesEndpoint ServicesEndpoint { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            var providerDtos = ServicesEndpoint.GetAllServiceProviders();
            var terminalWindow = new TermenalWindow(providerDtos);
            terminalWindow.Show();
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
