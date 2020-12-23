using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger).ConfigureAwait(true);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;
            switch (ex)
            {
                case RestException re:
                    logger.LogError(ex, "REST ERROR: \n\n");
                    errors = re.Errors;
                    context.Response.StatusCode = (int)re.Code;
                    break;

                case Exception e:
                    logger.LogError(ex, "SERVER ERROR: \n\n");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error: \t\t" : e.Message;
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new { errors });
                await context.Response.WriteAsync(result);
            }
        }
    }
}