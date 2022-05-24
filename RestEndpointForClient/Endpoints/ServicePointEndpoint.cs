using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicePointEndpoint : BaseEndpoint, IRestEndpoint<ServicePointDto>
    {
        private const string UrlController = URL_ROOT + "/ServicePoint";

        public void Delete(IEnumerable<long> toDelete)
        {
            _restApiClient.RequestDelete<IEnumerable<ServiceProviderDto>>(UrlController, toDelete);
        }

        public IEnumerable<ServicePointDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<ServicePointDto>>(UrlController);
        }

        public void Post(IEnumerable<ServicePointDto> toAdd)
        {
            _restApiClient.RequestPost<IEnumerable<ServiceProviderDto>>(UrlController, toAdd);
        }

        public void Put(IEnumerable<ServicePointDto> toUpdate)
        {
            _restApiClient.RequestPut<IEnumerable<ServiceProviderDto>>(UrlController, toUpdate);
        }
    }
}
