using ElectronicQueue.RestEndpoint.RestApi;

namespace ElectronicQueue.RestEndpoint.Endpoints
{
    public abstract class BaseEndpoint
    {
        protected const string URL_ROOT = "/api";

        protected readonly RestApiClient _restApiClient;
    }
}