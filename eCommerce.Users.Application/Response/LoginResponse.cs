namespace eCommerce.Users.Application.Response;

public sealed class LoginResponse
{
    public string Token { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public string Username { get; set; }
}
