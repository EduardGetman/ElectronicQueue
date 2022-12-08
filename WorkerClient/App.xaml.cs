using System.Configuration;
using System.Windows;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.WorkerClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            EndpoinCollection.ServerUrl = ConfigurationManager.AppSettings.Get("ServerUrl");
        }
    }
}
