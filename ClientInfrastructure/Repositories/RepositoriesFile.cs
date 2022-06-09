using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public class ServicesPointRepository : ModelRepository<ServicePointModel, ServicePointDto>
    {
        protected override IRestEndpoint<ServicePointDto> RestEndpoint => EndpoinCollection.ServicePoint;
    }
    public class ServicesRepository : ModelRepository<ServiceProviderModel, ServiceProviderDto>
    {
        protected override IRestEndpoint<ServiceProviderDto> RestEndpoint => EndpoinCollection.ServicesProvider;
    }
    public class QueueRepository : ModelRepository<QueueModel, QueueDto>
    {
        protected override IRestEndpoint<QueueDto> RestEndpoint => EndpoinCollection.Queue;
    }
    public class WorkerRepository : ModelRepository<WorkerModel, WorkerDto>
    {
        protected override IRestEndpoint<WorkerDto> RestEndpoint => EndpoinCollection.Worker;
    }
}
