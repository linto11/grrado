using FluentValidation;
using GRRADO.Shared.Application.Common.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace GRRADO.Shared.Infrastructure.Middleware;

/// <summary>
/// Global exception handling middleware shared across all microservices
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validation failed. CorrelationId: {CorrelationId}. Errors: {Errors}",
                context.Items["CorrelationId"]?.ToString() ?? "N/A",
                string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred. CorrelationId: {CorrelationId}",
                context.Items["CorrelationId"]?.ToString() ?? "N/A");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new
        {
            status = context.Response.StatusCode,
            message = ErrorCodes.VALIDATION_FAILED_MESSAGE,
            errors = exception.Errors.Select(e => new { field = e.PropertyName, error = e.ErrorMessage }),
            requestId = context.Items["CorrelationId"]?.ToString() ?? context.TraceIdentifier
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            status = context.Response.StatusCode,
            message = ErrorCodes.GENERIC_ERROR_MESSAGE,
            requestId = context.Items["CorrelationId"]?.ToString() ?? context.TraceIdentifier
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
