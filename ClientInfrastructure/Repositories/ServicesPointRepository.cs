using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.RestEndpoint;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public class ServicesPointRepository : ModelRepository<ServicePointModel, ServicePointDto>
    {
        protected override IRestEndpoint<ServicePointDto> RestEndpoint => EndpoinCollection.ServicePoint;
    }
}
