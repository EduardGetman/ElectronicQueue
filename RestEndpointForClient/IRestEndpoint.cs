using ElectronicQueue.Core.Application.Dto;
using System.Collections.Generic;

namespace ElectronicQueue.RestEndpoint
{
    public interface IRestEndpoint<TDto> where TDto : DtoBase
    {
        public IEnumerable<TDto> Get();
        public void Post(IEnumerable<TDto> toAdd);

        public void Put(IEnumerable<TDto> toUpdate);

        public void Delete(IEnumerable<long> toDelete);
    }
}
