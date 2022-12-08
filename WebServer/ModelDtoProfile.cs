using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.WebServer.Models;
using ElectronicQueue.WebServer.Models.DataModels;

namespace ElectronicQueue.WebServer;

public class ModelDtoProfile : Profile
{
    public ModelDtoProfile()
    {
        CreateMap<QueueDto, QueueDataModel>()
            .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets))
            .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.Provider.Name));
    }
}