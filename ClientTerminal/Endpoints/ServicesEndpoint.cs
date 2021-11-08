using ElectronicQueue.Data.Dto.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientTerminal.Endpoints
{
    static class ServicesEndpoint
    {
        public static IEnumerable<ServiceProviderDto> GetAllServiceProviders()
        {
            return new ServiceProviderDto[]
            {
                new ServiceProviderDto()
                {
                    Name = "Provider1",
                    Services = new ServiceDto[]
                    {
                        new ServiceDto()
                        {
                            Name = "Service1",
                            IsProvided = true
                        },
                        new ServiceDto()
                        {
                            Name = "Service2",
                            IsProvided = true
                        },
                        new ServiceDto()
                        {
                            Name = "IsNotProvided",
                            IsProvided = false
                        }
                    }
                },
                new ServiceProviderDto()
                {
                    Name = "Provider2",
                    Services = new ServiceDto[]
                    {
                        new ServiceDto()
                        {
                            Name = "Service1",
                            IsProvided = true
                        },
                        new ServiceDto()
                        {
                            Name = "Service2",
                            IsProvided = true
                        },
                        new ServiceDto()
                        {
                            Name = "IsNotProvided",
                            IsProvided = false
                        }
                    }
                }
            };
        }

        public static string AddTicket(ServiceDto service)
        {
            throw new NotImplementedException();
        }
    }
}
