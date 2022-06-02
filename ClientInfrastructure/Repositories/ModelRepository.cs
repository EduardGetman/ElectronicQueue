using AutoMapper;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.RestEndpoint;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.ClientInfrastructure.Repositories
{
    public abstract class ModelRepository<TModel, TDto> : IRepository<TModel>
        where TModel : ModelBase
        where TDto : DtoBase
    {

        private readonly IMapper _mapper;
        private List<TDto> _data;

        protected ModelRepository()
        {
            _mapper = DtoMapperConfiguration.CreateMapper();
        }

        public ICollection<TModel> Data
        {
            get
            {
                if (_data is null)
                {
                    Refresh();
                }
                return _data.Select(x => _mapper.Map<TModel>(x)).ToList();
            }
        }

        protected abstract IRestEndpoint<TDto> RestEndpoint { get; }

        public void Refresh() => _data = RestEndpoint.Get().Where(x => x != null).ToList();

        public void Save(IEnumerable<TModel> models)
        {
            var dto = models.Select(x => _mapper.Map<TDto>(x));
            var exsistedId = dto.Select(x => x.Id).ToList();

            var toAdd = dto.Where(x => x.Id == 0).ToList();
            var toUpdate = dto.Where(x => x.Id != 0 && !_data.Contains(x)).ToList();
            var toDelete = _data.Where(x => !exsistedId.Contains(x.Id)).Select(x => x.Id);

            if (toAdd.Any())
            {
                RestEndpoint.Post(toAdd);
            }
            if (toUpdate.Any())
            {
                RestEndpoint.Put(toUpdate);
            }
            if (toDelete.Any())
            {
                RestEndpoint.Delete(toDelete);
            }
        }
    }
}
