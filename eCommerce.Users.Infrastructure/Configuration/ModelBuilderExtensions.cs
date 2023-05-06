using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyAllConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ScopeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionScopeConfiguration());
    }
}
