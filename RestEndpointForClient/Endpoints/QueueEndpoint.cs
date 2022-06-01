using ElectronicQueue.Core.Application.Dto;
using System;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public class QueueEndpoint : BaseEndpoint, IRestEndpoint<QueueDto>
    {
        private const string UrlController = URL_ROOT + "/Queue";
        private const string PushUrlController = UrlController + "/Push";
        private const string SwitchStatusUrlController = UrlController + "/SwitchTicketStatus";

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
            _restApiClient.RequestPut<object>(UrlController, toUpdate);
        }

        public void Delete(IEnumerable<long> toDelete)
        {
            throw new NotImplementedException();
        }
        public TicketDto Push(TicketCreateDto dto)
        {
            return _restApiClient.RequestPost<TicketDto>(PushUrlController, dto);
        }
        public TicketDto SwitchTicketStatus(SwitchTicketStatusDto dto)
        {
            return _restApiClient.RequestPut<TicketDto>(SwitchStatusUrlController, dto);
        }
    }
}
