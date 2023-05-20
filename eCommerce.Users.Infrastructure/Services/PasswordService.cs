using eCommerce.Users.Application.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Users.Infrastructure.Services;

public sealed class PasswordService : IPasswordService
{
    private const int _keySize = 64;
    private const int _iterations = 350000;
    private readonly HashAlgorithmName _algorithmName = HashAlgorithmName.SHA512;

    public string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _algorithmName,
            _keySize
        );

        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _algorithmName,
            _keySize
        );

        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}
