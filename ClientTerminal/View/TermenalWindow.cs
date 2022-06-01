using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.RestEndpoint;
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
        private readonly IEnumerable<ServiceProviderDto> _serviceProviders;
        public TermenalWindow()
        {
            _serviceProviders = EndpoinCollection.ServicesProvider.GetProvided();

            InitializeComponent();

            FillButtonStackWithDto(_serviceProviders);
            VisibilityBackButton(false);
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
            while (ButtonStack.Children.Count > 1)
            {
                ButtonStack.Children.RemoveAt(1);
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
            if (sender is Button button)
            {
                if (button.Content is ServiceProviderDto provider)
                {
                    FillButtonStackWithDto(provider.Services.Where(s => s.IsProvided));
                    VisibilityBackButton(true);
                }
                else if (button.Content is ServiceDto service)
                {
                    EndpoinCollection.Queue.Push(new TicketCreateDto()
                    {
                        ProviderId = service.ProviderId,
                        ServiceId = service.Id
                    });
                }
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            VisibilityBackButton(false);
            FillButtonStackWithDto(_serviceProviders);
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
