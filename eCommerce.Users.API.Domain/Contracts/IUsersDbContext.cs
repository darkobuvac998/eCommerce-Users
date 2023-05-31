using eCommerce.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Domain.Contracts;

public interface IUsersDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Scope> Scopes { get; set; }
}
