namespace eCommerce.Users.Application.Abstractions;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(int userId, CancellationToken cancellationToken);
}
