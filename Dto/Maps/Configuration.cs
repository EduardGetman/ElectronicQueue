using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicQueue.Data.Dto.Maps
{
    public class Configuration
    {
        public static void Configure()
        {
#pragma warning disable CS0618 // Тип или член устарел
            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<QueueLogProfile>();
            //    x.AddProfile<QueueProfile>();
            //    x.AddProfile<ServiceProviderProfile>();
            //    x.AddProfile<ServicePointProfile>();
            //    x.AddProfile<ServiceStatisticProfile>();
            //    x.AddProfile<ServiceProfile>();
            //    x.AddProfile<SpecialTicketProfile>();
            //    x.AddProfile<TicketProfile>();
            //    x.AddProfile<WorkerLogProfile>();
            //    x.AddProfile<WorkerStatisticProfile>();
            //});
#pragma warning restore CS0618 // Тип или член устарел
        }
    }
}
