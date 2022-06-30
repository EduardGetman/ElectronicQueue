using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.EQServer
{
    public class DomainDtoProfile : Profile
    {
        public DomainDtoProfile()
        {
            CreateMap<QueueDomain, QueueDto>()
                .ForMember(dest => dest.Tickets, opt => opt.Ignore())
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ReverseMap();

            CreateMap<ServiceProviderDomain, ServiceProviderDto>()
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.Queue, opt => opt.MapFrom(src => src.Queue))
                .ForMember(dest => dest.ServicePoints, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<WorkerDomain, WorkerDto>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ReverseMap();

            CreateMap<AccountDomain, AccountDto>().ReverseMap();

            CreateMap<TicketDomain, TicketDto>()
                .ForMember(x=> x.Service , opt => opt.MapFrom(src => src.Service)).ReverseMap();

            CreateMap<ServicePointDomain, ServicePointDto>().ReverseMap();

            CreateMap<ServiceDomain, ServiceDto>().ReverseMap();

            CreateMap<ServiceProviderDomain, ServiceProviderShortDto>().ReverseMap();

            CreateMap<ServiceStatisticDomain, ServiceStatisticDto>().ReverseMap();

            CreateMap<QueueLogDomain, QueueLogDto>().ReverseMap();

            CreateMap<WorkerLogDomain, WorkerLogDto>().ReverseMap();

            CreateMap<WorkerStatisticDomain, WorkerStatisticDto>().ReverseMap();
        }
    }
}
