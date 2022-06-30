using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicesProviderEndpoint : BaseEndpoint, IRestEndpoint<ServiceProviderDto>
    {
        private const string UrlController = URL_ROOT + "/ServiceProvider";
        private const string ProvidedUrlController = UrlController + "/Provided";

        public ServicesProviderEndpoint(string serverUrl) : base(serverUrl)
        {
        }

        public IEnumerable<ServiceProviderDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<ServiceProviderDto>>(UrlController);
        }
        public IEnumerable<ServiceProviderDto> GetProvided()
        {
            return _restApiClient.RequestGet<IEnumerable<ServiceProviderDto>>(ProvidedUrlController);
        }
        public void Post(IEnumerable<ServiceProviderDto> toAdd)
        {
            _restApiClient.RequestPost<object>(UrlController, toAdd);
        }

        public void Put(IEnumerable<ServiceProviderDto> toUpdate)
        {
            _restApiClient.RequestPut<object>(UrlController, toUpdate);
        }

        public void Delete(IEnumerable<long> toDelete)
        {
            _restApiClient.RequestDelete<object>(UrlController, toDelete);
        }
    }
}
