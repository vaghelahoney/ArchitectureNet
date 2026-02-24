using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SuiteRx.Interface.Application.Common.Exceptions;
using SuiteRx.Interface.Application.Common.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.ErrorResponse("An internal server error occurred.");

            switch (exception)
            {
                case CustomValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = validationException.Message;
                    response.Errors = validationException.Errors;
                    break;
                case UnauthorizedAccessException _:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Message = "You do not have permission to access this resource.";
                    break;
                default:
                    // Usually you only show the exception message in development environments, 
                    // for this example we return the message as is.
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = exception.Message;
                    break;
            }

            // Using System.Text.Json to serialize the object properties nicely (avoiding default naming issues if needed)
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
