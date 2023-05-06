﻿using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Infrastructure.Contexts;

namespace eCommerce.Users.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UsersDbContext _usersDbContext;

    public UserRepository(UsersDbContext usersDbContext) => _usersDbContext = usersDbContext;

    public IQueryable<User> GetByEmail(string email)
    {
        return _usersDbContext.Users.Where(u => u.Email == email);
    }

    public IQueryable<User> GetByUsername(string username)
    {
        return _usersDbContext.Users.Where(u => u.Username == username);
    }
}