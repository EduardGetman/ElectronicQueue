using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class WorkerStatisticProfile : Profile
    {
        public WorkerStatisticProfile()
        {
            CreateMap<WorkerStatisticDomain, WorkerStatisticDto>().ReverseMap();
        }

    }
}
