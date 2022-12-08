namespace ElectronicQueue.WebServer.Models.DataModels;

public class QueueDataModel : DataModelBase
{
    public int NextTicketNumber { get; set; }
    public string Letters { get; set; }
    public bool IsEnabled { get; set; }
    public string ProviderName { get; set; }
    public List<TicketDataModel> Tickets { get; set; }
}