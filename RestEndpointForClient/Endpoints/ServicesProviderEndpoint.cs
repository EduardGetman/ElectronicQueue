using ElectronicQueue.Data.Dto.Entitys;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class ServicesProviderEndpoint : BaseEndpoint
    {
        private const string UrlController = URL_ROOT + "/ServiceProvider";
        public IEnumerable<ServiceProviderDto> GetAllServiceProviders()
        {
            return _restApiClient.RequestGet<IEnumerable<ServiceProviderDto>>(UrlController);
        }

        public static string AddTicket(ServiceDto service)
        {
            throw new NotImplementedException();
        }
    }
}
