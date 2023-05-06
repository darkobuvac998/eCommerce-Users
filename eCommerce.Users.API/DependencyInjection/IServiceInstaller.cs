namespace eCommerce.Users.API.DependencyInjection;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
