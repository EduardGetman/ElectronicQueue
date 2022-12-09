using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.WebServer.Models.DataModels;
using ElectronicQueue.WebServer.Models.ViewModels;
using ElectronicQueue.WebServer.Models.ViewModels.Queues;

namespace ElectronicQueue.WebServer.Interfaces;

public interface IQueuesService
{
    IndexViewModel CreateQueuesIndexModel();
    QueueViewModel CreateQueuesQueueModel(long providerId);
}