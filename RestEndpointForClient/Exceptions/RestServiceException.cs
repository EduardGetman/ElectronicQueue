using ElectronicQueue.RestEndpoint.Enums;
using System;

namespace ElectronicQueue.RestEndpoint.Exceptions
{
    class RestServiceException : Exception
    {
        public RestExceptionType RestExceptionType { get; }
        public RestServiceException(string path, RestExceptionType restExceptionType, Exception innerException = null, string json = "")
            : base(GetExceptionMessage(restExceptionType, path, json), innerException)
        {

        }

        private static string GetExceptionMessage(RestExceptionType restExceptionType, string path, string json)
        {
            string pathMessage = $"Путь: \"{path}\"";
            string jsonMessage = $"Ответ сервера: \"{json}\"";
            switch (restExceptionType)
            {
                case RestExceptionType.ServerException:
                    return $"Сервер ошибку. \n {pathMessage}";
                case RestExceptionType.SuccessResponseParseException:
                    return $"Возникла ошибка при попытке установить соединение с сервером.\n {pathMessage}";
                case RestExceptionType.ErrorResponcePraceExceprion:
                    return $"Ответ от сервера был пустой строкой. {pathMessage}";
                case RestExceptionType.EmptyResponceException:
                    return $"Сервер вернул ошибку. Неудалось десериализовать текст ответа.\n {pathMessage} \n {jsonMessage}";
                case RestExceptionType.ConnectionException:
                    return $"Сервер вернул результат. Неудалось десериализовать текст ответа.\n {pathMessage} \n {jsonMessage}";

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
