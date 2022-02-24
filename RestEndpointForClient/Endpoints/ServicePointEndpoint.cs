using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicePointEndpoint : BaseEndpoint
    {
        private const string UrlController = URL_ROOT + "/ServicePoint";
        public IEnumerable<ServicePointDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<ServicePointDto>>(UrlController);
        }
    }
}
