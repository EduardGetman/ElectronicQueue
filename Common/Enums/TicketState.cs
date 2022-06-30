using ElectronicQueue.Data.Common.Attributes;

namespace ElectronicQueue.Data.Common.Enums
{
    public enum TicketState
    {
        [Name("Ожидает вызова")]
        Waiting,

        [Name("Вызван")]
        Called,

        [Name("Обслуживается")]
        Servicing,

        [Name("Обслужен")]
        Serviced,

        [Name("Необслужен")]
        NotServiced,
    }
}