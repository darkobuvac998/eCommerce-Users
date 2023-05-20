using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Infrastructure.Authentication;
using eCommerce.Users.Infrastructure.Contexts;
using eCommerce.Users.Infrastructure.OptionsSetup;
using eCommerce.Users.Infrastructure.Repositories;
using eCommerce.Users.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.API.DependencyInjection;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var provider = services.BuildServiceProvider();
        var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<UsersDbContext>(
            options =>
                options
                    .UseNpgsql(
                        configuration.GetConnectionString("Db"),
                        optionsBuilder =>
                        {
                            optionsBuilder
                                .MigrationsAssembly("eCommerce.Users.Infrastructure")
                                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        }
                    )
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
        );

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.ConfigureOptions<RedisOptionsSetup>();

        services.AddStackExchangeRedisCache(redisOptions =>
        {
            redisOptions.Configuration = configuration.GetConnectionString("Redis");
        });

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IPasswordService, PasswordService>();
    }
}
