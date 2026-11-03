using LibraryApi.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApi.Filters;

public class ExceptionHandlingFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionHandlingFilter> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionHandlingFilter(
        ILogger<ExceptionHandlingFilter> logger, IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled || context.HttpContext.Response.HasStarted)
            return;

        _logger.LogError(context.Exception,
            "Unhandled exception in MVC action {ActionName} for request {TraceId}.",
            context.ActionDescriptor.DisplayName, context.HttpContext.TraceIdentifier);

        var problem = ExceptionProblemDetailsFactory.Create(
            context.Exception, context.HttpContext, _environment);
        var result = new ObjectResult(problem)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        result.ContentTypes.Add("application/problem+json");

        context.HttpContext.Response.Headers["X-Request-Id"] = context.HttpContext.TraceIdentifier;
        context.Result = result;
        context.ExceptionHandled = true;
    }
}
