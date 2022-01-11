using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domains
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
