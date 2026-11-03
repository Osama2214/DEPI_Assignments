using LibraryApi.Data;
using LibraryApi.Extensions;
using LibraryApi.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<LibraryDbContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeeding.SeedAsync(
            context, app.Environment.ContentRootPath);
        var authenticationContext = services.GetRequiredService<AuthenticationDbContext>();
        await authenticationContext.Database.MigrateAsync();
    }
    catch (Exception exception)
    {
        logger.LogError(exception, "An error occurred while preparing the database.");
        throw;
    }
}

app.UseMiddleware<RequestTimingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestIdHeaderMiddleware>();
app.UseMiddleware<RateLimitingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(ApplicationServiceExtension.CorsPolicyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "Library database is ready.");

app.Run();
