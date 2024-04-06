using API.Errors;

namespace API.Exceptions
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string? message = null,string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
