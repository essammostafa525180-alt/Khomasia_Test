using Domain.Shared;
using System.Net;
using System.Text.Json;

namespace Hadith.WebApi.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
    public GlobalErrorHandlingMiddleware(RequestDelegate next, 
        ILogger<GlobalErrorHandlingMiddleware> logger)
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
            _logger.LogError(ex,ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        var stackTrace = String.Empty;
        string message;
        var exceptionType = exception.GetType();
        if (exceptionType == typeof(Exceptions.BadRequestException))
        {
            message = exception.Message;
            status = HttpStatusCode.BadRequest;
            stackTrace = exception.StackTrace;
        }
        else if (exceptionType == typeof(Exceptions.NotFoundException))
        {
            message = exception.Message;
            status = HttpStatusCode.NotFound;
            stackTrace = exception.StackTrace;
        }
        else if (exceptionType == typeof(Exceptions.AmbiguousException))
        {
            message = exception.Message;
            status = HttpStatusCode.Ambiguous;
            stackTrace = exception.StackTrace;
        }
        else if (exceptionType == typeof(Exceptions.InternalServerErrorException))
        {
            message = exception.Message;
            status = HttpStatusCode.InternalServerError;
            stackTrace = exception.StackTrace;
        }
        //else if (exceptionType == typeof(Exceptions.NotImplementedException))
        //{
        //    status = HttpStatusCode.NotImplemented;
        //    message = exception.Message;
        //    stackTrace = exception.StackTrace;
        //}
        else if (exceptionType == typeof(Exceptions.UnauthorizedAccessException))
        {
            status = HttpStatusCode.Unauthorized;
            message = exception.Message;
            stackTrace = exception.StackTrace;
        }
        else if (exceptionType == typeof(Exceptions.KeyNotFoundException))
        {
            status = HttpStatusCode.Unauthorized;
            message = exception.Message;
            stackTrace = exception.StackTrace;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = exception.Message;
            stackTrace = exception.StackTrace;
        }
        var exceptionResult = JsonSerializer.Serialize(Result<string>.Failure(message)
       , new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(exceptionResult);
    }
}
