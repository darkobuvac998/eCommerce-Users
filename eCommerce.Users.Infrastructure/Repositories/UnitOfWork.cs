using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly UsersDbContext _usersDbContext;
    private IUserRepository _userRepository;
    private IScopeRepository _scopeRepository;
    private IResourceRepository _resourceRepository;

    public UnitOfWork(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_usersDbContext);

    public DbContext Context => _usersDbContext;

    public IScopeRepository Scopes => _scopeRepository ??= new ScopeRepository(_usersDbContext);

    public IResourceRepository Resources =>
        _resourceRepository ??= new ResourceRepository(_usersDbContext);

    public async Task RollbackChangesAcync(CancellationToken cancellationToken)
    {
        foreach (
            var entry in _usersDbContext.ChangeTracker
                .Entries()
                .Where(e => e.State != EntityState.Unchanged)
        )
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                case EntityState.Deleted:
                    await entry.ReloadAsync(cancellationToken);
                    break;
            }
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _usersDbContext.SaveChangesAsync(cancellationToken);
    }
}
