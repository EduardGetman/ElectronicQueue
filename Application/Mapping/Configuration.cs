using AutoMapper;
using System;
using System.Reflection;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class DtoMapperConfiguration
    {
        private static readonly MapperConfiguration _configuration = new MapperConfiguration(x =>
        {
            x.AddProfile<QueueLogProfile>();
            x.AddProfile<QueueProfile>();
            x.AddProfile<ServiceProviderProfile>();
            x.AddProfile<ServicePointProfile>();
            x.AddProfile<ServiceStatisticProfile>();
            x.AddProfile<ServiceProfile>();
            x.AddProfile<SpecialTicketProfile>();
            x.AddProfile<TicketProfile>();
            x.AddProfile<WorkerLogProfile>();
            x.AddProfile<WorkerStatisticProfile>();

            x.AllowNullCollections = true;
            x.AllowNullDestinationValues = true;
        });
        public static IMapper CreateMapper() => _configuration.CreateMapper();
        public static Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();
    }
}
