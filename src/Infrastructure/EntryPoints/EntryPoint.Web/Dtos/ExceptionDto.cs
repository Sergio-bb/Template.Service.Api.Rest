using System.Net;

namespace Template.Service.Api.Rest.Domain.Model
{

    public class CustomHttpException(string message,
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}

