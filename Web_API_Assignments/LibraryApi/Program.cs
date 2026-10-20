using LibraryApi.Data;
using LibraryApi.Extensions;
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
    }
    catch (Exception exception)
    {
        logger.LogError(exception, "An error occurred while preparing the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "Library database is ready.");

app.Run();
