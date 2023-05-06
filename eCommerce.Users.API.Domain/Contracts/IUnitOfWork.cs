using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Domain.Contracts;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IScopeRepository Scopes { get; }
    IResourceRepository Resources { get; }
    DbContext Context { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task RollbackChangesAcync(CancellationToken cancellationToken);
}
