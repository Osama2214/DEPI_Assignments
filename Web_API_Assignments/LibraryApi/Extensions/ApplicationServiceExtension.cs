using LibraryApi.Data;
using LibraryApi.Data.Interceptors;
using LibraryApi.Filters;
using LibraryApi.Helper;
using LibraryApi.Middlewares;
using LibraryApi.Repositories;
using LibraryApi.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(new SoftDeleteInterceptor(),
                    new CreatedAtInterceptor(), new ModifiedAtInterceptor()));

        services.AddAutoMapper(options =>
            options.AddProfile<LibraryProfile>());

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddTransient<RequestIdHeaderMiddleware>();
        services.AddScoped<ActionExecutionLoggingFilter>();
        services.AddScoped<ActionTimingFilter>();
        services.AddScoped<ExceptionHandlingFilter>();

        return services;
    }
}
