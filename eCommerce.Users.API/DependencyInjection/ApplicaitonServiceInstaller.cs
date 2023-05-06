using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Infrastructure.Authentication;

namespace eCommerce.Users.API.DependencyInjection;

public sealed class ApplicaitonServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblyContaining<Application.AseemblyReference>()
        );

        services.AddAutoMapper(Application.AseemblyReference.Assembly);
    }
}
