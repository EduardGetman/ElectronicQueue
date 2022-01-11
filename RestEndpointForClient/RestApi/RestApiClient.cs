using ElectronicQueue.RestEndpoint.Enums;
using ElectronicQueue.RestEndpoint.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ElectronicQueue.RestEndpoint.RestApi
{
    public class RestApiClient
    {
        private const string ServerBaseUrl = "https://localhost:44357";
        private readonly IRestClient _restClient;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        public RestApiClient()
        {
            _restClient = new RestClient(ServerBaseUrl);
        }

        private IRestRequest CreateRequest(string path, Method method, Dictionary<string, object> parametrs = null, TimeSpan? timeout = null, object body = null)
        {
            var request = new RestRequest(path, method, DataFormat.Json);

            if (timeout != null)
            {
                request.Timeout = (int)timeout.Value.TotalMilliseconds;
            }

            if (parametrs != default)
            {
                foreach (var parametr in parametrs)
                {
                    request.AddParameter(parametr.Key, parametr.Value);
                }
            }

            if (body != default)
            {
                request.AddJsonBody(body);
            }
            return request;
        }

        public T RequestGet<T>(string path, Dictionary<string, object> parametrs = default)
        {
            var request = CreateRequest(path, Method.GET, parametrs, _timeout);
            var response = _restClient.Execute(request);

            if (!response.IsSuccessful)
                ThrowExeceptoin(path, response);

            if (string.IsNullOrEmpty(response.Content))
                ThrowExeceptoin(path);

            return ProcessSucessResponse<T>(response.Content, path);
        }
        public T RequestDelete<T>(string path, object value) => RequestWithBudy<T>(path, value, Method.DELETE);

        public T RequestPost<T>(string path, object value) => RequestWithBudy<T>(path, value, Method.POST);

        public T RequestPut<T>(string path, object value) => RequestWithBudy<T>(path, value, Method.PUT);

        private T RequestWithBudy<T>(string path, object value, Method method)
        {
            var request = CreateRequest(path, method, timeout: _timeout, body: value);
            var response = _restClient.Execute(request);

            if (!response.IsSuccessful)
                ThrowExeceptoin(path, response);

            return ProcessSucessResponse<T>(response.Content, path);
        }

        private T ProcessSucessResponse<T>(string json, string path)
        {
            try
            {
                using (var sw = new StringReader(json))
                using (var reader = new JsonTextReader(sw))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(reader);
                }
            }
            catch (JsonException ex)
            {
                throw new RestServiceException(path, RestExceptionType.SuccessResponseParseException, ex, json);
            }
        }

        private void ThrowExeceptoin(string path, IRestResponse response = null)
        {
            if (response != null)
                throw new RestServiceException(path, RestExceptionType.EmptyResponceException);

            if (response.ErrorException is WebException webException)
                throw new RestServiceException(path, RestExceptionType.ConnectionException, webException);

            throw new RestServiceException(path, RestExceptionType.ServerException);
        }
    }
}
