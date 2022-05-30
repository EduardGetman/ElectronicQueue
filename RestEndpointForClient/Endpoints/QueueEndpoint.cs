using ElectronicQueue.Core.Application.Dto;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class QueueEndpoint : BaseEndpoint, IRestEndpoint<QueueDto>
    {
        private const string UrlController = URL_ROOT + "/Queue";

        public IEnumerable<QueueDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<QueueDto>>(UrlController);
        }

        public void Post(IEnumerable<QueueDto> toAdd)
        {
            throw new NotImplementedException();
        }

        public void Put(IEnumerable<QueueDto> toUpdate)
        {
            _restApiClient.RequestPut<IEnumerable<QueueDto>>(UrlController, toUpdate);
        }

        public void Delete(IEnumerable<long> toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
