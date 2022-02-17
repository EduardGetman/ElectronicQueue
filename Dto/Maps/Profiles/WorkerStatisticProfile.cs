using AutoMapper;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Dto.Entitys.Statistic;

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
