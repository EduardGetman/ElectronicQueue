using AutoMapper;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.AdminClient.Infrastructure.Repositories
{
    public class ServicesRepository : IRepository<ServiceProviderModel>
    {
        private readonly Mapper _mapper;
        private List<ServiceProviderDto> _data;

        public ServicesRepository()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<ServiceProviderDto, ServiceProviderModel>());
            _mapper = new Mapper(config);
        }

        public ICollection<ServiceProviderModel> Data 
        { 
            get 
            {
                if (_data is null)
                {
                    Refresh();
                }
                return _data.Select(x => _mapper.Map<ServiceProviderModel>(x)).ToList();
            } 
        }

        public void Refresh()
        {
            _data = EndpoinCollection.ServicesProvider.Get()
                                                                .Where(x => x != null)
                                                                .ToList();
        }

        public void Save(IEnumerable<ServiceProviderModel> models)
        {
            var dto = models.Select(x => _mapper.Map<ServiceProviderDto>(x));
            var toAdd = dto.Where(x => x.Id == default).ToList();
            var ToUpdate = dto.Except(_data).Where(x => x.Id == default).ToList();
        }
    }
}
