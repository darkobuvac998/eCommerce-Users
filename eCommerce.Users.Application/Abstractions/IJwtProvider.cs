using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Application.Abstractions;

public interface IJwtProvider
{
    Task<JwtResult> GenerateTokenAsync(User user, CancellationToken cancellationToken);
}
