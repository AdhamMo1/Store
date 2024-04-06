using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace API.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var details = new ProblemDetails()
            {
                Detail= $"Api Error , {exception.Message}",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Api Error",
                Type = "Server Error"
            };
            var response = JsonSerializer.Serialize(details);
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(response, cancellationToken);

            return true;
        }
    }
}
