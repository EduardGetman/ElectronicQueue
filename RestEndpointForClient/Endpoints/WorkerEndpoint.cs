using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class WorkerEndpoint : BaseEndpoint, IRestEndpoint<WorkerDto>
    {
        private const string UrlController = URL_ROOT + "/Worker";
        private const string UrlAutorizeController = UrlController + "/Autorize";
        private const string UrlDeauthorizeController = UrlController + "/Deauthorize";

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

        public AutorizeResounseDto Autorize(AccountDto accountDto)
        {
            return _restApiClient.RequestPut<AutorizeResounseDto>(UrlAutorizeController, accountDto);
        }

        public void Deauthorize(long workerId)
        {
            _restApiClient.RequestPut<AutorizeResounseDto>(UrlDeauthorizeController, workerId);
        }
    }
}
