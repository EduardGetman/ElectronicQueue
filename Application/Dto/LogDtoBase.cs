using System;

namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Базовый класс логов
    /// </summary>
    public abstract class LogDtoBase : DtoBase
    {
        public DateTime EventDateTime { get; set; }
    }
}
