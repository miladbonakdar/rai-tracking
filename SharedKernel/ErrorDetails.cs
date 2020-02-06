using System;
using Newtonsoft.Json;

namespace SharedKernel
{
    public class ErrorDetail
    {
        public ErrorDetail(int statusCode, string message, string stackTrace)
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = stackTrace;
        }

        public int StatusCode { get; }
        public string Message { get; }
        public string StackTrace { get; }
        public override string ToString()
            => JsonConvert.SerializeObject(this);

        public static ErrorDetail NotFound(string message, string stackTrace)
            => new ErrorDetail(404, message, stackTrace);
        public static ErrorDetail NotFound(Exception e)
            => NotFound(e.Message, e.StackTrace);


        public static ErrorDetail AccessDenied(string message, string stackTrace)
            => new ErrorDetail(403, message, stackTrace);
        public static ErrorDetail AccessDenied(Exception e)
            => AccessDenied(e.Message, e.StackTrace);


        public static ErrorDetail BadRequest(string message, string stackTrace)
            => new ErrorDetail(400, message, stackTrace);
        public static ErrorDetail BadRequest(Exception e)
            => BadRequest(e.Message, e.StackTrace);


        public static ErrorDetail Unauthorized(string message, string stackTrace)
            => new ErrorDetail(401, message, stackTrace);
        public static ErrorDetail Unauthorized(Exception e)
            => Unauthorized(e.Message, e.StackTrace);
    }
}
