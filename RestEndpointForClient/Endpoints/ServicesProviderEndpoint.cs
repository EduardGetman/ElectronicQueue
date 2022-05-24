using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicesProviderEndpoint : BaseEndpoint, IRestEndpoint<ServiceProviderDto>
    {
        private const string UrlController = URL_ROOT + "/ServiceProvider";

        public IEnumerable<ServiceProviderDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<ServiceProviderDto>>(UrlController);
        }

        public void Post(IEnumerable<ServiceProviderDto> toAdd)
        {
            _restApiClient.RequestPost<IEnumerable<ServiceProviderDto>>(UrlController, toAdd);
        }

        public void Put(IEnumerable<ServiceProviderDto> toUpdate)
        {
            _restApiClient.RequestPut<IEnumerable<ServiceProviderDto>>(UrlController, toUpdate);
        }

        public void Delete(IEnumerable<long> toDelete)
        {
            _restApiClient.RequestDelete<IEnumerable<long>>(UrlController, toDelete);
        }
    }
}
