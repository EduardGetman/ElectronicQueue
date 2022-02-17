using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class ServiceStatisticProfile : Profile
    {
        public ServiceStatisticProfile()
        {
            CreateMap<ServiceStatisticDomain, ServiceStatisticDto>().ReverseMap();
        }

    }
}
