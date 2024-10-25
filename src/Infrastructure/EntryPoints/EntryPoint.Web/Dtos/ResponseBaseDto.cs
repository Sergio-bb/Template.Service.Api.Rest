using System.Net;

namespace Template.Service.Api.Rest.EntryPoint.Web.Dtos
{
    public class ResponseBaseDto<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Result { get; set; }
        public string? Error  { get; set; } //change the type depending your necessity

        public ResponseBaseDto<T> Success(T data, string message = "The request was completed successfully")
        {
            return new ResponseBaseDto<T>
            {
                Result = data,
                Message = message
            };
        }

        public ResponseBaseDto<T> Fail(string error,  string message = "Something has gone wrong, try again. If the error persists, contact your system administrator.")
        {
            return new ResponseBaseDto<T>
            {
                Result = default,
                Message = message, 
                Error = error
            };
        }
    }
    
}
