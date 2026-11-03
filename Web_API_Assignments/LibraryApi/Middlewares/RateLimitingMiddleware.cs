using System.Diagnostics;
using System.Globalization;

namespace LibraryApi.Middlewares;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly object _lock = new();
    private long _windowStart = Stopwatch.GetTimestamp();
    private int _counter;

    public RateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var retryAfter = 0;
        lock (_lock)
        {
            var elapsed = Stopwatch.GetElapsedTime(_windowStart);
            if (elapsed >= TimeSpan.FromSeconds(10))
            {
                _windowStart = Stopwatch.GetTimestamp();
                _counter = 0;
                elapsed = TimeSpan.Zero;
            }

            if (_counter >= 10)
                retryAfter = Math.Max(1, (int)Math.Ceiling(10 - elapsed.TotalSeconds));
            else
                _counter++;
        }

        if (retryAfter > 0)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.Headers["Retry-After"] = retryAfter.ToString(CultureInfo.InvariantCulture);
            await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
            return;
        }

        await _next(context);
    }
}
