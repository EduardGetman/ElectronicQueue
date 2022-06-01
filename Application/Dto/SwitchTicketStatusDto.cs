using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.Core.Application.Dto
{
    public class SwitchTicketStatusDto
    {
        public long ProviderId { get; set; }
        public long ServicePointId { get; set; }
        public TicketState NewState { get; set; }
    }

}