using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class DtoModelProfile : Profile
    {
        public DtoModelProfile()
        {
            CreateMap<QueueLogDto, QueueModel>().ReverseMap();
            CreateMap<QueueDto, QueueModel>()
                    .ForMember(dest => dest.Tikets, opt => opt.MapFrom(src => src.Tickets))
                    .ReverseMap();
            CreateMap<ServicePointModel, ServicePointDto>().ReverseMap();
            CreateMap<ServiceModel, ServiceDto>().ReverseMap();
            CreateMap<SpecialTicketDomain, SpecialTicketDto>().ReverseMap();
            CreateMap<TicketModel, TicketDto>().ReverseMap();
            CreateMap<WorkerLogDomain, WorkerLogDto>().ReverseMap();
            CreateMap<WorkerStatisticDomain, WorkerStatisticDto>().ReverseMap();

            CreateMap<ServiceProviderModel, ServiceProviderDto>()
                    .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
                    .ReverseMap();
            CreateMap<ServiceProviderModel, ServiceProviderShortDto>().ReverseMap();
        }
    }
}
