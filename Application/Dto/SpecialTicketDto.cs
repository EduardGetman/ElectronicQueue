namespace ElectronicQueue.Core.Application.Dto
{
    /// <summary>
    /// Талон на обслуживание вне обычной очереди
    /// </summary>
    public class SpecialTicketDto : TicketDto
    {
        public bool IsConfirmed { get; set; }
        public string Info { get; set; }
    }
}
