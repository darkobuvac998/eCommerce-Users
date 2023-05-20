using System.ComponentModel.DataAnnotations;

namespace eCommerce.Users.Infrastructure.Options;

public sealed class RedisOptions
{
    [Required]
    public int CacheExpiration { get; set; } = 60;
}
