using AutoMapper;
using ElectronicQueue.RestEndpoint;
using ElectronicQueue.WebServer.Interfaces;
using ElectronicQueue.WebServer.Models.DataModels;
using ElectronicQueue.WebServer.Models.DataModels.ViewModels;

namespace ElectronicQueue.WebServer.Services;

public class QueuesService : IQueuesService
{
    private readonly IMapper _mapper;

    public QueuesService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<QueueDataModel> GetQueues()
    {
        foreach (var dto in EndpoinCollection.Queue.Get())
        {
            var dataModel = _mapper.Map<QueueDataModel>(dto);
            dataModel.Tickets.AddRange(dto.Tickets.Select(x => _mapper.Map<TicketDataModel>(x)));
            yield return dataModel;
        }
    }

    public QueuesIndexModel CreateQueuesIndexModel()
    {
        return new QueuesIndexModel()
        {
            Queues = GetQueues().ToList()
        };
    }
}