using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.Statistic;
using ElectronicQueue.Data.Dto.Entitys.Statistic;

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
