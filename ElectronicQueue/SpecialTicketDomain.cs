namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Талон на обслуживание вне обычной очереди
    /// </summary>
    public class SpecialTicketDomain : TicketDomain
    {
        public bool IsConfirmed { get; set; }
        public string Info { get; set; }
    }
}
