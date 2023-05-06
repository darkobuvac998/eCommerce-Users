using System.ComponentModel.DataAnnotations;

namespace eCommerce.Users.Presentation.Requests;

public class LoginRequest
{
    public string Username { get; set; }
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
