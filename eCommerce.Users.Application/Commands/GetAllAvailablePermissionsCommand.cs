using eCommerce.Users.Application.Abstractions.Commands;
using eCommerce.Users.Application.Response;

namespace eCommerce.Users.Application.Commands;

public sealed record GetAllAvailablePermissionsCommand() : ICommand<AvailablePermissionsResponse>;
