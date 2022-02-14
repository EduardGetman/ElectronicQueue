using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class ServiceProviderProfile : Profile
    {
        public ServiceProviderProfile()
        {
            CreateMap<ServiceProviderDomain, ServiceProviderDto>()
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.Queue, opt => opt.MapFrom(src => src.Queue))
                .ForMember(dest => dest.ServicePoints, opt => opt.MapFrom(src => src.ServicePoints))
                .ReverseMap();
            CreateMap<ServiceProviderModel, ServiceProviderDto>().ReverseMap();
        }
    }
}
