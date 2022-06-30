using ElectronicQueue.RestEndpoint.Endpoints;

namespace ElectronicQueue.RestEndpoint
{
    public static class EndpoinCollection
    {
        public static string ServerUrl { get; set; }
        private static ServicesProviderEndpoint _servicesProvider;
        private static ServicePointEndpoint _servicePoint;
        private static QueueEndpoint _queue;
        private static WorkerEndpoint _worker;
        public static ServicesProviderEndpoint ServicesProvider
        {
            get
            {
                if (_servicesProvider is null)
                {
                    _servicesProvider = new ServicesProviderEndpoint(ServerUrl);
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
                    _servicePoint = new ServicePointEndpoint(ServerUrl);
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
                    _queue = new QueueEndpoint(ServerUrl);
                }
                return _queue;
            }
        }
        public static WorkerEndpoint Worker
        {
            get
            {
                if (_worker is null)
                {
                    _worker = new WorkerEndpoint(ServerUrl);
                }
                return _worker;
            }
        }
    }
}
