using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public class ServicesRepository : ModelRepository<ServiceProviderModel, ServiceProviderDto>
    {
        protected override IRestEndpoint<ServiceProviderDto> RestEndpoint => EndpoinCollection.ServicesProvider;
    }
}