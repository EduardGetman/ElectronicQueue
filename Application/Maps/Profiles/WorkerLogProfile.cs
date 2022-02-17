using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

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
