using AutoMapper;
using ElectronicQueue.AdminClient.Interfaces;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.Data.Models;
using ElectronicQueue.RestEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }
    }
}
