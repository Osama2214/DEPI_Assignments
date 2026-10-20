using LibraryApi.Data;
using LibraryApi.Helper;
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
                configuration.GetConnectionString("DefaultConnection")));

        services.AddAutoMapper(options =>
            options.AddProfile<LibraryProfile>());

        return services;
    }
}
