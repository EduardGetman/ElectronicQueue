using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class WorkerEndpoint : BaseEndpoint, IRestEndpoint<WorkerDto>
    {
        private const string UrlController = URL_ROOT + "/Worker";

        public IEnumerable<WorkerDto> Get()
        {
            return _restApiClient.RequestGet<IEnumerable<WorkerDto>>(UrlController);
        }
        public void Delete(IEnumerable<long> toDelete)
        {
            _restApiClient.RequestDelete<object>(UrlController, toDelete);
        }

        public void Post(IEnumerable<WorkerDto> toAdd)
        {
            _restApiClient.RequestPost<object>(UrlController, toAdd);
        }

        public void Put(IEnumerable<WorkerDto> toUpdate)
        {
            _restApiClient.RequestPut<object>(UrlController, toUpdate);
        }
    }
}
