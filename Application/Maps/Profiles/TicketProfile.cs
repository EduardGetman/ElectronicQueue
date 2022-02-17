using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketDomain, TicketDto>().ReverseMap();
            CreateMap<TicketModel, TicketDto>().ReverseMap();
        }
    }
}
