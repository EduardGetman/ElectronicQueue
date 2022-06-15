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
            TicketState.Called => new[] { TicketState.Servicing, TicketState.NotServiced },
            TicketState.Servicing => new[] { TicketState.Serviced },
            _ => Enumerable.Empty<TicketState>(),
        }; 
        public ServicePointState? GetServicePointState(TicketState newTicketState) => newTicketState switch
        {
            TicketState.Called => ServicePointState.WaitNext,
            TicketState.Servicing => ServicePointState.Servicing,
            TicketState.NotServiced => ServicePointState.Free,
            TicketState.Serviced => ServicePointState.Free,
            _ => null,
        };
    }
}
