using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.AdminClient.Infrastructure.Repositories
{
    public class ServicesPointRepository : ModelRepository<ServicePointModel, ServicePointDto>
    {
        protected override IRestEndpoint<ServicePointDto> RestEndpoint => EndpoinCollection.ServicePoint;
    }
    public class ServicesRepository : ModelRepository<ServiceProviderModel, ServiceProviderDto>
    {
        protected override IRestEndpoint<ServiceProviderDto> RestEndpoint => EndpoinCollection.ServicesProvider;
    }
}
