using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class SpecialTicketProfile : Profile
    {
        public SpecialTicketProfile()
        {
            CreateMap<SpecialTicketDomain, SpecialTicketDto>().ReverseMap();
        }
    }
}
