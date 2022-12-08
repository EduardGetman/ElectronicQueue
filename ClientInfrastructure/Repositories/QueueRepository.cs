using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public class QueueRepository : ModelRepository<QueueModel, QueueDto>
    {
        protected override IRestEndpoint<QueueDto> RestEndpoint => EndpoinCollection.Queue;
    }
}