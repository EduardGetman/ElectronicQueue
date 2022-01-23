using AutoMapper;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicQueue.AdminClient.Infrastructure.Repositories
{
    public class ServicesRepository : IRepository<ServiceProviderModel>
    {
        private readonly Mapper _mapper;
        private List<ServiceProviderDto> _data;

        public ServicesRepository()
        {
        }

        public ICollection<ServiceProviderModel> GetCollection()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<ServiceProviderDto, ServiceProviderModel>());
            var mapper = new Mapper(config);
            if (_data is null)
            {
                LoadData();
            }
            return _data.Select(x => mapper.Map<ServiceProviderModel>(x)).ToList();
        }

        public bool Refresh()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        private void LoadData()
        {
            _data = EndpoinCollection.ServicesProvider.GetAllServiceProviders()
                                                                .Where(x => x != null)
                                                                .ToList();
        }
    }
}
