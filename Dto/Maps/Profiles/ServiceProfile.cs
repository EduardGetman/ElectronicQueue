using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceDomain, ServiceDto>().ReverseMap();
            CreateMap<ServiceModel, ServiceDto>().ReverseMap();
        }
    }
}
