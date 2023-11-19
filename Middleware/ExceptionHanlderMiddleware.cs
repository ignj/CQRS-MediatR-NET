using System.Net;
using System.Net.Mime;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException e)
        {
            logger.LogWarning("Not Found. {e}", e.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        catch (ConflictException e)
        {
            logger.LogWarning("Conflict. {e}", e.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync($@"{{""msg"": ""{e.Message}"" }}");
        }
        catch (Exception e)
        {
            logger.LogCritical("Unhandled exception. {e}", e.ToString());
        }
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandler(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}