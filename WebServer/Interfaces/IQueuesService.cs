using ElectronicQueue.WebServer.Models.DataModels;
using ElectronicQueue.WebServer.Models.DataModels.ViewModels;

namespace ElectronicQueue.WebServer.Interfaces;

public interface IQueuesService
{
    IEnumerable<QueueDataModel> GetQueues();
    QueuesIndexModel CreateQueuesIndexModel();
}