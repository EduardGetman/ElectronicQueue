using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.Queue;
using ElectronicQueue.Data.Dto.Entitys.Queue;

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
