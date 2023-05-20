using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Presentation.Requests;

public class SignInRequest
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
}
