using ClientTerminal.View;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Interfaces;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClientTerminal
{
    /// <summary>
    /// Логика взаимодействия для TermenalWindow.xaml
    /// </summary>
    public partial class TermenalWindow : Window
    {
        private const string ProviderChoiseWindowName = "Выберите сервис";
        private const string ServiceChoiseWindowName = "Выберите услугу";
        private readonly ITicketPrinter _ticketPrinter = null;
        private readonly IEnumerable<ServiceProviderDto> _serviceProviders;
        public string WindowNameText
        {
            get => WindowNameTextBlock.Text;
            set => WindowNameTextBlock.Text = value;
        }
        public TermenalWindow()
        {
            _serviceProviders = EndpoinCollection.ServicesProvider.GetProvided();

            InitializeComponent();

            FillButtonStackWithDto(_serviceProviders);
            VisibilityBackButton(false);
            WindowNameText = ProviderChoiseWindowName;
        }
        private void FillButtonStackWithDto(IEnumerable<DtoBase> dto)
        {
            if (dto is null)
            {
                WarningMessage("Отсутвует список услуг");
            }
            ButtonStackClear();
            foreach (var services in dto)
            {
                if (services is null) continue;

                ButtonStack.Children.Add(CreateButton(services));
            }
        }

        private void ButtonStackClear()
        {
            while (ButtonStack.Children.Count > 2)
            {
                ButtonStack.Children.RemoveAt(2);
            }
        }

        private Button CreateButton(DtoBase provider)
        {
            var button = new Button { Content = provider };
            button.Click += ClickButton;
            return button;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button)
                {
                    if (button.Content is ServiceProviderDto provider)
                    {
                        FillButtonStackWithDto(provider.Services.Where(s => s.IsProvided));
                        VisibilityBackButton(true);
                        WindowNameText = ServiceChoiseWindowName;
                    }
                    else if (button.Content is ServiceDto service)
                    {
                        var ticket = EndpoinCollection.Queue.Push(new TicketCreateDto()
                        {
                            ProviderId = service.ProviderId,
                            ServiceId = service.Id
                        });
                        _ticketPrinter?.PrintTicket(ticket);
                        var window = new TicketPresentWindow(ticket);
                        window.ShowDialog();
                        BackButtonClick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                WarningMessage(ex.Message);
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            VisibilityBackButton(false);
            FillButtonStackWithDto(_serviceProviders);
            WindowNameText = ProviderChoiseWindowName;
        }
        private static void WarningMessage(string message)
        {
            MessageBox.Show(message, "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void VisibilityBackButton(bool isVisible)
        {
            BackButton.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
