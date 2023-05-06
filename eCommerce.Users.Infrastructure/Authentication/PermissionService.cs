using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Authentication;

public sealed class PermissionService : IPermissionService
{
    private readonly UsersDbContext _dbContext;

    public PermissionService(UsersDbContext dbContext) => _dbContext = dbContext;

    public async Task<HashSet<string>> GetPermissionsAsync(
        int userId,
        CancellationToken cancellationToken
    )
    {
        var permissions = await _dbContext.Users
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .ThenInclude(p => p.Scopes)
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Roles)
            .SelectMany(u => u.Permissions)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var permissionNames = new List<string>();

        foreach (var permission in permissions)
        {
            string permissionName = "";
            foreach (var scope in permission.Scopes)
            {
                permissionName = $"{permission.Resource.Name}-{scope.Name}";
                permissionNames.Add(permissionName);
            }
        }

        return permissionNames.ToHashSet();
    }
}
