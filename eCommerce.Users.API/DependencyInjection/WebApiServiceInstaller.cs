using eCommerce.Users.API.Middlewares;

namespace eCommerce.Users.API.DependencyInjection;

public class WebApiServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<GlobalExceptionHandlingMiddleware>();
    }
}
