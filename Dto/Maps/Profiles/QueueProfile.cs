using AutoMapper;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Dto.Entitys.Queue;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<QueueDomain, QueueDto>().ReverseMap();
            CreateMap<QueueDto, QueueModel>().ReverseMap();
        }
    }
}
