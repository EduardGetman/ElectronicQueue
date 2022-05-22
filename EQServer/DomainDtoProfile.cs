using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.EQServer
{
    public class DomainDtoProfile : Profile
    {
        public DomainDtoProfile()
        {
            CreateMap<QueueLogDomain, QueueLogDto>().ReverseMap();
            CreateMap<QueueDomain, QueueDto>().ReverseMap();
            CreateMap<ServicePointDomain, ServicePointDto>().ReverseMap();
            CreateMap<ServiceDomain, ServiceDto>().ReverseMap();
            CreateMap<ServiceProviderDomain, ServiceProviderDto>()
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.Queue, opt => opt.MapFrom(src => src.Queue))
                .ForMember(dest => dest.ServicePoints, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ServiceStatisticDomain, ServiceStatisticDto>().ReverseMap();
            CreateMap<SpecialTicketDomain, SpecialTicketDto>().ReverseMap();
            CreateMap<TicketDomain, TicketDto>().ReverseMap();
            CreateMap<WorkerLogDomain, WorkerLogDto>().ReverseMap();
            CreateMap<WorkerStatisticDomain, WorkerStatisticDto>().ReverseMap();
        }
    }
}
