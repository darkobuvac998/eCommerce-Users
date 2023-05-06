using System.Reflection;

namespace eCommerce.Users.API.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies
    )
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies
            .SelectMany(e => e.DefinedTypes)
            .Where(IsAssignableType<IServiceInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (var serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        return services;

        static bool IsAssignableType<T>(TypeInfo type) =>
            typeof(T).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface;
    }
}
