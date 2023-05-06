using eCommerce.Users.Application.Abstractions.Commands;
using eCommerce.Users.Application.Response;

namespace eCommerce.Users.Application.Commands;

public sealed record LoginCommand(string? Username, string? Email, string Password)
    : ICommand<LoginResponse>;
