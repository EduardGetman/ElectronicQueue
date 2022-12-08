using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public class WorkerRepository : ModelRepository<WorkerModel, WorkerDto>
    {
        protected override IRestEndpoint<WorkerDto> RestEndpoint => EndpoinCollection.Worker;
    }
}