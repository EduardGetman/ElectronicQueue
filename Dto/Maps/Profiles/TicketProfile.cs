using AutoMapper;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Dto.Entitys.Queue;
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
