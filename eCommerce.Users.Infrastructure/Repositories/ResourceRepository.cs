using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Repositories;

public sealed class ResourceRepository : IResourceRepository
{
    private readonly UsersDbContext _usersDbContext;

    public ResourceRepository(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public DbSet<Resource> Entity => _usersDbContext.Set<Resource>();
}
