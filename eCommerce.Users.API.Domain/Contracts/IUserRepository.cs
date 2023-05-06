using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Domain.Contracts;

public interface IUserRepository
{
    IQueryable<User> GetByUsername(string username);
    IQueryable<User> GetByEmail(string email);
}
