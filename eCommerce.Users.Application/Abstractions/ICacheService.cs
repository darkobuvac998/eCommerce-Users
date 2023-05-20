namespace eCommerce.Users.Application.Abstractions;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default);
    Task SetAsync<T>(
        string key,
        T value,
        TimeSpan timeSpan = default,
        CancellationToken cancellationToken = default
    );
}
