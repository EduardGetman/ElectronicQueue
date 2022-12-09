using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.WebServer.Models.DataModels;

namespace ElectronicQueue.WebServer;

public class ModelDtoProfile : Profile
{
    public ModelDtoProfile()
    {
        CreateMap<QueueDto, QueueDataModel>()
            .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets))
            .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.Provider.Name))
            .ForMember(dest => dest.ProviderId, opt => opt.MapFrom(src => src.Provider.Id));
        
        CreateMap<TicketDto, TicketDataModel>()
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
            .ForMember(dest => dest.CallingServicePointLocation,
                opt => opt.MapFrom(src => src.СallingServicePoint.Location));
    }
}