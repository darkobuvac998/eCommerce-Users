namespace eCommerce.Users.Domain.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(string code, string message)
        : base(code, message) { }
}
