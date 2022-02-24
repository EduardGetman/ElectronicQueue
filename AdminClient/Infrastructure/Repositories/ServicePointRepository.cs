using AutoMapper;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.AdminClient.Infrastructure.Repositories
{
    public class ServicePointRepository : IRepository<ServicePointModel>
    {
        private readonly IMapper _mapper;
        private List<ServicePointDto> _data;

        public ServicePointRepository()
        {
            _mapper = DtoMapperConfiguration.CreateMapper();
        }
        public ICollection<ServicePointModel> Data
        {
            get
            {
                if (_data is null)
                {
                    Refresh();
                }
                return _data.Select(x => _mapper.Map<ServicePointModel>(x)).ToList();
            }
        }

        public void Refresh()
        {

            _data = EndpoinCollection.ServicePoint.Get()
                                                      .Where(x => x != null)
                                                      .ToList();
        }

        public void Save(IEnumerable<ServicePointModel> models)
        {
            var oldModels = Data;
            var changedModels = models.Except(oldModels).ToList();
            var toAdd = changedModels.Where(x => x.Id == default);
            var toUpdate = changedModels.Where(x => x.Id != default);
            var toDelete = oldModels.Except(models);

            if (toUpdate.Any()) { }
        }
    }
}
