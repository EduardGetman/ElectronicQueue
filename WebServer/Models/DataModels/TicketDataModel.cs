using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.WebServer.Models.DataModels;

public class TicketDataModel : DataModelBase
{
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public TicketState State { get; set; }
    public string ServiceName { get; set; }
    public string CallingServicePointLocation { get; set; }
}