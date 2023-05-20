using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Services;

public sealed class RoleService : IRoleService
{
    private readonly UsersDbContext _dbContext;

    public RoleService(UsersDbContext dbContext) => (_dbContext) = (dbContext);

    public async Task<List<string>> GetUserRolesAsync(
        int userId,
        CancellationToken cancellation = default
    )
    {
        var roles = await _dbContext.Users
            .Include(u => u.Roles)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles.Select(u => u.Name))
            .SelectMany(x => x)
            .Distinct()
            .ToListAsync();

        return roles;
    }
}
