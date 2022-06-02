using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Common.Extansion;
using System;

namespace ElectronicQueue.Core.Application.Models
{
    /// <summary>
    /// Талон на обслуживание
    /// </summary>
    public class TicketModel : ModelBase
    {
        private TicketState _state;
        private long _serviceId;
        private long _queueId;
        private ServiceModel _service;
        private DateTime _createTime;
        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public DateTime CreateTime
        {
            get => _createTime;
            set => Set(ref _createTime, value);
        }
        public TicketState State
        {
            get => _state;
            set => Set(ref _state, value);
        }
        public long ServiceId
        {
            get => _serviceId;
            set => Set(ref _serviceId, value);
        }
        public long QueueId
        {
            get => _queueId;
            set => Set(ref _queueId, value);
        }
        public ServiceModel Service
        {
            get => _service;
            set => Set(ref _service, value);
        }
        public string ServiceName => Service?.Name ?? "Не определено";
        public string StateName => State.ToName();
    }
}