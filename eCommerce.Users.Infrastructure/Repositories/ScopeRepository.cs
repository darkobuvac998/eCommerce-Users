using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Repositories;

public sealed class ScopeRepository : IScopeRepository
{
    private readonly UsersDbContext _usersDbContext;

    public ScopeRepository(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public DbSet<Scope> Entity => _usersDbContext.Set<Scope>();
}
