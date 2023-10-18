
using Azure.Core.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                //context.Features.Get<IExceptionHandlerFeature>();

            } catch (Exception ex)
            {
                _logger.LogError(ex, message: ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                   Status = (int) HttpStatusCode.InternalServerError,
                   Type = "Server Error",
                   Title = $"An Internal Server Error has occurred: {ex.Message}",
                   Detail = ex.Message,
                };

                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
           
        }
    }
}
