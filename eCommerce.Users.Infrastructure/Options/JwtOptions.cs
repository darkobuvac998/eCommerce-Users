using System.ComponentModel.DataAnnotations;

namespace eCommerce.Users.Infrastructure.Options;

public class JwtOptions
{
    [Required]
    public string Audience { get; set; }

    [Required]
    public string Issuer { get; set; }

    [Required]
    public string SecretKey { get; set; }

    [Required]
    public int ExpirationTime { get; set; } = 1;
}
