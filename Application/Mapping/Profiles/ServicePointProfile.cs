using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;
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
