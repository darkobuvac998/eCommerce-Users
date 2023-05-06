namespace eCommerce.Users.Application.Response;

public sealed class JwtResult
{
    public string Token { get; set; }
    public string Username { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}
