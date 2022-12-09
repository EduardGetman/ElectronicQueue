using ElectronicQueue.WebServer.Models.DataModels;

namespace ElectronicQueue.WebServer.Models.ViewModels.Queues;

public class IndexViewModel
{
    public string WebServerUrl { get; set; }
    public List<QueueDataModel> Queues { get; set; } = new();
}