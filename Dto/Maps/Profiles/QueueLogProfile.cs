using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.LogDomain;
using ElectronicQueue.Data.Dto.Entitys.Log_;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class QueueLogProfile : Profile
    {
        public QueueLogProfile()
        {
            CreateMap<QueueLogDomain, QueueLogDto>().ReverseMap();
            CreateMap<QueueLogDto, QueueModel>().ReverseMap();
        }
    }
}
