using System.Net;

namespace Template.Service.Api.Rest.EntryPoint.Web.Dtos
{

    public class CustomHttpException(string message,
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}

