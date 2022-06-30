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
            CreateMap<QueueDto, QueueModel>()
                    .ForMember(dest => dest.Tikets, opt => opt.MapFrom(src => src.Tickets))
                    .ReverseMap();

            CreateMap<ServiceProviderModel, ServiceProviderDto>()
                    .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
                    .ReverseMap();

            CreateMap<WorkerModel, WorkerDto>()
                    .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                    .ReverseMap();

            CreateMap<AccountModel, AccountDto>().ReverseMap();

            CreateMap<ServicePointModel, ServicePointDto>().ReverseMap();

            CreateMap<ServiceModel, ServiceDto>().ReverseMap();

            CreateMap<TicketModel, TicketDto>()
                    .ForMember(dest => dest.СallingServicePoint, opt => opt.MapFrom(src => src.Point)).ReverseMap();

            CreateMap<WorkerLogDomain, WorkerLogDto>().ReverseMap();

            CreateMap<WorkerStatisticDomain, WorkerStatisticDto>().ReverseMap();

            CreateMap<ServiceProviderModel, ServiceProviderShortDto>().ReverseMap();

            CreateMap<QueueLogDto, QueueModel>().ReverseMap();
        }
    }
}
