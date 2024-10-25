using System.Net;
using Template.Service.Api.Rest.EntryPoint.Web.Dtos;

namespace Template.Service.Api.Rest.Application.Host.Midellwares
{
    public class GlobalExceptionHandler(IWebHostEnvironment env) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {                
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = GetStatusCode(exception);
            context.Response.StatusCode = (int)statusCode;

            var response = new ResponseBaseDto<object>()
                .Fail(env.IsDevelopment() ? exception.ToString() : exception.Message);
            await context.Response.WriteAsJsonAsync(response);
        }

        private static HttpStatusCode GetStatusCode(Exception exception)
        {
            return exception switch
            {
                CustomHttpException httpException => httpException.StatusCode,
                KeyNotFoundException => HttpStatusCode.NotFound,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                ArgumentException => HttpStatusCode.BadRequest,
                // Add more exception mappings as needed
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}
