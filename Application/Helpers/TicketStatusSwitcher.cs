using ElectronicQueue.Data.Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.Core.Application.Helpers
{
    public class TicketStatusSwitcher
    {
        public TicketState State { get; set; }
        public TicketStatusSwitcher(TicketState state)
        {
            State = state;
        }
        public IEnumerable<TicketState> NextTicketStates => State switch
        {
            TicketState.Waiting => new[] { TicketState.Called, TicketState.NotServiced },
            TicketState.Called => new[] { TicketState.Serviced, TicketState.NotServiced },
            TicketState.Serviced => new[] { TicketState.Closed },
            _ => Enumerable.Empty<TicketState>(),
        };
    }
}
