using System.Diagnostics;

namespace LibraryApi.Middlewares;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        var failed = false;
        try
        {
            await _next(context);
        }
        catch
        {
            failed = true;
            throw;
        }
        finally
        {
            stopwatch.Stop();
            if (failed)
                _logger.LogError("HTTP {Method} {Path} failed after {ElapsedMilliseconds} ms.",
                    context.Request.Method, context.Request.Path, stopwatch.Elapsed.TotalMilliseconds);
            else
                _logger.LogInformation("HTTP {Method} {Path} returned {StatusCode} in {ElapsedMilliseconds} ms.",
                    context.Request.Method, context.Request.Path,
                    context.Response.StatusCode, stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
