using System;

namespace ElectronicQueue.Data.Dto.Entitys.Log_
{
    /// <summary>
    /// Базовый класс логов
    /// </summary>
    public abstract class LogDtoBase : DtoBase
    {
        public DateTime EventDateTime { get; set; }
    }
}
