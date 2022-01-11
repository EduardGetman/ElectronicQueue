using ElectronicQueue.RestEndpoint.Endpoints;

namespace ElectronicQueue.RestEndpoint
{
    public static class EndpoinCollection
    {
        public static ServicesProviderEndpoint ServicesProvider => new ServicesProviderEndpoint();
    }
}
