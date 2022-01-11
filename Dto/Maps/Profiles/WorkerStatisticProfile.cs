using AutoMapper;
using ElectronicQueue.Data.Domain.Domains.Statistic;
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
