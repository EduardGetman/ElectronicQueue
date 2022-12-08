using System.Collections.Generic;
using System.Linq;
using ElectronicQueue.Data.Common.Enums;

namespace ElectronicQueue.WorkerClient.ViewModel
{
    public class ServicePointStateSwithcer
    {
        public ServicePointState State;
        public ServicePointStateSwithcer(ServicePointState state)
        {
            State = state;
        }
        public IEnumerable<ServicePointState> NextStates => State switch
        {
            ServicePointState.Closed => new[] { ServicePointState.Free },
            ServicePointState.Free => new[] { ServicePointState.Closed, ServicePointState.Paused, ServicePointState.WaitNext },
            ServicePointState.Paused => new[] { ServicePointState.Free, ServicePointState.Closed },
            ServicePointState.Servicing => new[] { ServicePointState.Free },
            ServicePointState.WaitNext => new[] { ServicePointState.Servicing, ServicePointState.Free },
            _ => Enumerable.Empty<ServicePointState>(),
        };
        public bool CanChangeState(ServicePointState newState) => NextStates.Contains(newState);
        public bool StateEqual(params ServicePointState[] oldState) => oldState.Contains(State);
    }
}