using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Domains;
using ElectronicQueue.Data.Models;

namespace ElectronicQueue.Data.Dto.Entitys
{
    /// <summary>
    /// Обслуживающий сервис
    /// </summary>
    public class ServicePointDto : DtoBase
    {
        public string Location { get; set; }
        public ServicePointState ServicePointState { get; set; }
        public long? ProviderId { get; set; }
        public ServicePointDto(ServicePointDomain domain) : base(domain)
        {
            Location = domain.Location;
            ServicePointState = domain.ServicePointState;
            ProviderId = domain.ProviderId;
        }
        public ServicePointDto(ServicePointModel model) : base(model)
        {
            Location = model.Location;
            ServicePointState = model.ServicePointState;
            ProviderId = model.ProviderId;
        }
        public ServicePointDomain ToDomain()
        {
            var domain = ToDomain<ServicePointDomain>();
            domain.Location = Location;
            domain.ProviderId = ProviderId;
            domain.ServicePointState = ServicePointState;
            return domain;
        }
        public ServicePointModel ToModel()
        {
            var model = ToModel<ServicePointModel>();
            model.Location = Location;
            model.ProviderId = ProviderId;
            model.ServicePointState = ServicePointState;
            return model;
        }
    }
}