namespace eCommerce.Users.Application.Abstractions;

public interface IPasswordService
{
    string HashPassword(string password, out byte[] salt);
    bool VerifyPassword(string password, string hash, byte[] salt);
}
