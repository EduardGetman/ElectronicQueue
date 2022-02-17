using AutoMapper;
using ElectronicQueue.Core.Domain;
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
