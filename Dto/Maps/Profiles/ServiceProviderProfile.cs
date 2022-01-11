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
            CreateMap<ServiceProviderDomain, ServiceProviderDto>().ReverseMap();
            CreateMap<ServiceProviderModel, ServiceProviderDto>().ReverseMap();
        }
    }
}
