using System.Text;
using LibraryApi.Data;
using LibraryApi.Data.Interceptors;
using LibraryApi.Filters;
using LibraryApi.Helper;
using LibraryApi.Middlewares;
using LibraryApi.Models;
using LibraryApi.Repositories;
using LibraryApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

namespace LibraryApi.Extensions;

public static class ApplicationServiceExtension
{
    public const string CorsPolicyName = "ConfigurationOrigins";

    public static IServiceCollection AddServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter the JWT returned by account/login."
            });
            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            });
        });

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

        services.AddDbContext<AuthenticationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AuthenticationConnection")));
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            options.User.RequireUniqueEmail = true)
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();

        var jwtKey = configuration["Jwt:Key"];
        if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetByteCount(jwtKey) < 32)
            throw new InvalidOperationException(
                "Set Jwt:Key to a random key of at least 32 bytes using user secrets or environment variables.");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ClockSkew = TimeSpan.Zero
            };
        });
        services.AddScoped<IJwtService, JwtService>();

        var origins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
        services.AddCors(options => options.AddPolicy(CorsPolicyName, policy =>
        {
            if (origins.Length > 0)
                policy.WithOrigins(origins);
            policy.AllowAnyMethod().AllowAnyHeader();
        }));

        return services;
    }
}
