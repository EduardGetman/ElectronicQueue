using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using System;
using System.Collections.Generic;
using System.Text;

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
