using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicesProviderEndpoint : BaseEndpoint
    {
        private const string UrlController = URL_ROOT + "/ServiceProvider";
        public IEnumerable<ServiceProviderDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<ServiceProviderDto>>(UrlController);
        }
        public IEnumerable<ServiceProviderDto> Save(IEnumerable<ServiceProviderDto> toAdd, IEnumerable<ServiceProviderDto> toUpdate)
        {
            return _restApiClient.RequestPost<IEnumerable<ServiceProviderDto>>(UrlController,
                                                                              new Dictionary<string, object>
                                                                              {
                                                                                  { nameof(toAdd), toAdd },
                                                                                  { nameof(toUpdate), toUpdate }
                                                                              });
        }
    }
}
