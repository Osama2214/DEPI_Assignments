namespace LibraryApi.Middlewares;

public class RequestIdHeaderMiddleware : IMiddleware
{
    private readonly ILogger<RequestIdHeaderMiddleware> _logger;

    public RequestIdHeaderMiddleware(ILogger<RequestIdHeaderMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Response.Headers["X-Request-Id"] = context.TraceIdentifier;
        _logger.LogDebug("Assigned request ID {RequestId} to {Method} {Path}.",
            context.TraceIdentifier, context.Request.Method, context.Request.Path);
        await next(context);
    }
}
