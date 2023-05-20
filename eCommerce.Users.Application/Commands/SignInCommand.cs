using eCommerce.Users.Application.Abstractions.Commands;
using eCommerce.Users.Application.Response;

namespace eCommerce.Users.Application.Commands;

public sealed record SignInCommand(
    string? Name,
    string? Surname,
    string? Username,
    string? Email,
    string? Password
) : ICommand<SignInResponse>;
