using ElectronicQueue.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Core.Application.Interfaces
{
    public interface ITicketPrinter
    {
        public void PrintTicket(TicketDto ticketDto);
    }
}
