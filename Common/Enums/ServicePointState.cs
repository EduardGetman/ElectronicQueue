using ElectronicQueue.Data.Common.Attributes;

namespace ElectronicQueue.Data.Common.Enums
{
    public enum ServicePointState
    {
        [Name("Не работатет")]
        Closed,

        [Name("Свободен")]
        Free,

        [Name("Ожидает клиента")]
        WaitNext,

        [Name("Обслуживает")]
        Servicing,

        [Name("Обслуживание приостановленно")]
        Paused
    }
}