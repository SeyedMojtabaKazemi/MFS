namespace MFS.Endpoint.WebAPI.Extensions
{
    public class ErrorDetails
    {
        public int StatusCode { get; }
        public string Message { get; }
        public string Detail { get; }
        public bool IsError { get; }

        public ErrorDetails(int statusCode, string message, string detail)
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
            IsError = true;
        }
    }
}
