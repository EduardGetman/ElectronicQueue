using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.LogDomain;
using ElectronicQueue.Data.Dto.Entitys.Log_;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class WorkerLogProfile : Profile
    {
        public WorkerLogProfile()
        {
            CreateMap<WorkerLogDomain, WorkerLogDto>().ReverseMap();
        }
    }
}
