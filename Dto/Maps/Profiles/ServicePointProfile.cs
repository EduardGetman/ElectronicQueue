using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.OrganizationInfo;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class ServicePointProfile : Profile
    {
        public ServicePointProfile()
        {
            CreateMap<ServicePointDomain, ServicePointDto>().ReverseMap();
            CreateMap<ServicePointModel, ServicePointDto>().ReverseMap();
        }
    }
}
