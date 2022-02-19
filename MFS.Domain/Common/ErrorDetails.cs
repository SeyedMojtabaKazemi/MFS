namespace MFS.Domain.Common
{
    public class ErrorDetails
    {
        public int StatusCode { get; }
        public string Message { get; }
        public string Path { get; }

        public ErrorDetails(int statusCode, string message, string path)
        {
            StatusCode = statusCode;
            Message = message;
            Path = path;
        }
    }
}
