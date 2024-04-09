
namespace API.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode,string? message = null)
        {
            _statusCode = statusCode;
            _message = message ?? GetDefualtMessage(statusCode);
        }
        public int _statusCode { get; set; }
        public string _message { get; set; }
        private string GetDefualtMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Requset";
                    break;
                case 401:
                    return "UnAuthorized";
                    break;
                case 404:
                    return "Not Found";
                    break;
                case 500:
                    return "Server Error";
                    break;
                default:
                    return null;

            }

        }
    }
}
