using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Domain.Contracts;

public interface IRepository<T>
    where T : class
{
    DbSet<T> Entity { get; }
}
