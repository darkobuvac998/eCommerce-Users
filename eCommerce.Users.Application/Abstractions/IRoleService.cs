namespace eCommerce.Users.Application.Abstractions;

public interface IRoleService
{
    Task<List<string>> GetUserRolesAsync(int userId, CancellationToken cancellation = default);
}
