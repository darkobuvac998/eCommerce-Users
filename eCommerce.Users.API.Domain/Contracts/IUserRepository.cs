using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Domain.Contracts;

public interface IUserRepository : IRepository<User>
{
    IQueryable<User> GetByUsername(string username);
    IQueryable<User> GetByEmail(string email);
}
