using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApi.Filters;

public class ActionExecutionLoggingFilter : IActionFilter
{
    private readonly ILogger<ActionExecutionLoggingFilter> _logger;

    public ActionExecutionLoggingFilter(ILogger<ActionExecutionLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Starting MVC action {ActionName}.",
            context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        if (context.Exception != null && !context.ExceptionHandled)
        {
            _logger.LogError(context.Exception, "MVC action {ActionName} failed.", actionName);
            return;
        }

        _logger.LogInformation("Finishing MVC action {ActionName}.", actionName);
    }
}
