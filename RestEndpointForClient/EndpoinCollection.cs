using ElectronicQueue.RestEndpoint.Endpoints;

namespace ElectronicQueue.RestEndpoint
{
    public static class EndpoinCollection
    {
        private static ServicesProviderEndpoint _servicesProvider;
        private static ServicePointEndpoint _servicePoint;
        private static QueueEndpoint _queue;
        public static ServicesProviderEndpoint ServicesProvider
        {
            get
            {
                if (_servicesProvider is null)
                {
                    _servicesProvider = new ServicesProviderEndpoint();
                }
                return _servicesProvider;
            }
        }

        public static ServicePointEndpoint ServicePoint
        {
            get
            {
                if (_servicePoint is null)
                {
                    _servicePoint = new ServicePointEndpoint();
                }
                return _servicePoint;
            }
        }

        public static QueueEndpoint Queue
        {
            get
            {
                if (_queue is null)
                {
                    _queue = new QueueEndpoint();
                }
                return _queue;
            }
        }
    }
}
