using ElectronicQueue.RestEndpoint.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.RestEndpoint
{
    public static class EndpoinCollection
    {
        public static ServicesProviderEndpoint ServicesProvider => new ServicesProviderEndpoint();
    }
}
