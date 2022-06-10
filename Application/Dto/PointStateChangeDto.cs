using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.Core.Application.Dto
{
    public class PointStateChangeDto
    {
        public ServicePointState ServicePointState { get; set; }
        public long ServicePointId { get; set; }
        public long ProviderId { get; set; }
        public long WorkerId { get; set; }
    }
}