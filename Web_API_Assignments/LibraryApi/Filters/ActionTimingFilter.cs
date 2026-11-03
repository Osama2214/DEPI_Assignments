using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApi.Filters;

public class ActionTimingFilter : IAsyncActionFilter
{
    private readonly ILogger<ActionTimingFilter> _logger;

    public ActionTimingFilter(ILogger<ActionTimingFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await next();
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation("MVC action {ActionName} took {ElapsedMilliseconds} ms.",
                context.ActionDescriptor.DisplayName, stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
